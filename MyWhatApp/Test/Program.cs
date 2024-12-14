//using Model;
//using ViewModel;
using MModel;
using VViewModel;

#region City
//CityDB cDB = new CityDB();
//CityList cities =cDB.SelectAll();
//foreach (City c in cities )
//    Console.WriteLine(c.CityName);
//City cLast = cities.Last();
//cDB.Delete(cLast);
//cDB.SaveChanges();
//Console.WriteLine( "delete :");
//cities =  cDB.SelectAll();
//foreach (City c in cities)
//    Console.WriteLine(c.CityName);

City cy = new City() { CityName = "Nesher" };
CityDB cDB = new CityDB();
cDB.Insert(cy);
cDB.SaveChanges();
CityList cities = cDB.SelectAll();
foreach (City cts in cities )
    Console.WriteLine(cts.CityName);

#endregion

#region School
//SchoolDB sDb = new SchoolDB();
//SchoolList s = sDb.SelectAll();
//foreach (School c in s)
//    Console.WriteLine("schools "+c.SchoolName + " " + c.SchoolCity.CityName);
//School scLast = s.Last();
//sDb.Delete(scLast);
//sDb.SaveChanges();
//Console.WriteLine("delete :");
//s = sDb.SelectAll();
//foreach (School c in s)
//    Console.WriteLine(":)"+c.SchoolName + " " + c.SchoolCity.CityName);

#endregion

#region Student

School sc = SchoolDB.SelectById(1);
StudentDB sDB = new StudentDB();
StudentList sts = sDB.SelectAll();
Console.WriteLine("students list before :");
foreach (Student c in sts)
    Console.WriteLine(c.FName + " " + c.TZ);
Student sLast = sts.Last();
sDB.Delete(sLast);
sDB.SaveChanges();
Console.WriteLine("delete :");
sts = sDB.SelectAll();
foreach (Student c in sts)
    Console.WriteLine(c.FName + " " + c.TZ);

#endregion
//#region
//UserDB uDB = new UserDB();
//UserList uList = uDB.SelectAll();
//foreach(User ur in uList)
//    Console.WriteLine(ur.UserName+" "+ur.UserCity.CityName);




//#endregion




//#region
//MemberDb mDb = new();
//MemberList mList = mDb.SelectAll();
//Console.WriteLine("Member "+mList.Count);
//Member m = new()
//{
//    NickName = "gugi",
//    TelNumber = "0589874133",
//    Pic = "C:\\Users\\nativ\\source\\repos\\HishtalmutMaui\\ViewModel\\Images\\boy2.webp"
//};


//mDb.Insert(m);
//int x1=mDb.SaveChanges();
//Console.WriteLine(x1);
//Member m1 = mList[0];
//m1.TelNumber = "0555555555";
//mDb.Update(m1);
//x1 = mDb.SaveChanges();
//Console.WriteLine(x1);
//#endregion
//#region
////TEST GROUPTYPE
//GroupTypeDB gtDB = new();
//GroupTypeList gtList = gtDB.SelectAll();
//Console.WriteLine(gtList.Count);
//GroupType g = new GroupType() { Description = "אחר" };
//gtDB.Insert(g);
//int x = gtDB.SaveChanges();
//gtList = gtDB.SelectAll();
//Console.WriteLine("--" + gtList.Count);
//gtList.Last().Description = "משהו אחר";
//gtDB.Update(gtList.Last());
//x = gtDB.SaveChanges();
//gtList = gtDB.SelectAll();
//Console.WriteLine(gtList.Count);
//foreach (var item in gtList)
//    Console.WriteLine(item.Description + " " + item.Id);
//g = gtList.Last();
//gtDB.Delete(g);
//x = gtDB.SaveChanges();
//Console.WriteLine(x);
//#endregion

//#region
////TEST GROUP
//GroupDB gDB = new();
//GroupList gList = gDB.SelectAll();
//Console.WriteLine("group:"+gList.Count);
//Group g1 = new Group()
//{
//    GroupEstablish = new DateTime(2021, 7, 11),
//    GroupName = "My graet family",
//    GroupTp= gtList.First(),
//    IdCreator = m1
//};
//gDB.Insert(g1);
//x = gDB.SaveChanges();
//Console.WriteLine(x);
//#endregion


