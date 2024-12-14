﻿using MModel;
using System.Data;
using System.Data.OleDb;

namespace VViewModel
{
    public abstract class BaseEntityDB
    {        
        protected static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" 
            +Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location
            + "/../../../../../VViewModel/ExampleProjectBagrutGrades.accdb");
        protected static OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;





        public BaseEntityDB()
        {
            connection ??= new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        public abstract BaseEntity NewEntity();

        



        protected List<BaseEntity> Select()
        {
            List<BaseEntity> list = new List<BaseEntity>();
            try
            {
                command.Connection = connection;
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BaseEntity entity = NewEntity();
                    list.Add(CreateModel(entity));
                }
            }
            
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine(
                    e.Message + "\nSQL:" + command.CommandText);
            }
            finally
            {
                if (reader != null) reader.Close();
             //   if (connection.State == ConnectionState.Open) connection.Close();
            }
            return list;
        }

        protected async Task<List<BaseEntity>> SelectAsync(string sqlStr)
        {
            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command = new OleDbCommand();
            List<BaseEntity> list = new List<BaseEntity>();

            try
            {
                command.Connection = connection;
                command.CommandText = sqlStr;
                connection.Open();
                this.reader = (OleDbDataReader)await command.ExecuteReaderAsync();


                while (reader.Read())
                {
                    BaseEntity entity = NewEntity();
                    list.Add(CreateModel(entity));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + command.CommandText);
            }
            finally
            {
                if (reader != null) reader.Close();
                if (connection.State == ConnectionState.Open) connection.Close();
            }

            return list;
        }
        

        protected virtual BaseEntity CreateModel(BaseEntity entity)
        {
            entity.Id = (int)reader["id"];
            return entity;
        }

        protected abstract void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd);

        public static List<ChangeEntity> deleted = new List<ChangeEntity>();
       
       

        public virtual void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
            }
        }

        public virtual void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }


        protected abstract void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd);

        public static List<ChangeEntity> inserted = new List<ChangeEntity>();


        public int SaveChanges()
        {
            OleDbTransaction trans = null;
            int records_affected = 0;

            try
            {
                command.Connection = connection;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                trans = connection.BeginTransaction();
                command.Transaction = trans;

                foreach (var entity in inserted)
                {
                    command.Parameters.Clear();
                    entity.CreateSql(entity.Entity, command);       //cmd.CommandText = CreateInsertSQL(entity.Entity);
                    records_affected += command.ExecuteNonQuery();

                    command.CommandText = "Select @@Identity";
                    entity.Entity.Id = (int)command.ExecuteScalar();
                }

                //foreach (var entity in updated)
                //{
                //    command.Parameters.Clear();
                //    entity.CreateSql(entity.Entity, command); //cmd.CommandText = CreateUpdateSQL(entity.Entity);
                //    records_affected += command.ExecuteNonQuery();
                //}

                foreach (var entity in deleted)
                {
                    command.Parameters.Clear();
                    entity.CreateSql(entity.Entity, command);

                    records_affected += command.ExecuteNonQuery();
                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                System.Diagnostics.Debug.WriteLine(ex.Message + "\n SQL:" + command.CommandText);
            }
            finally
            {
               // inserted.Clear();
                //updated.Clear();
                deleted.Clear();

                //if (connection.State == System.Data.ConnectionState.Open)
                //    connection.Close();
            }

            return records_affected;
        }

    }
}