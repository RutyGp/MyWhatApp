//using Model;
//using ViewModel;
using ApiInterface;
using MModel;
using VViewModel;


//CityDB cdb = new();
//CityList cList = cdb.SelectAll();
//Console.WriteLine(cList.Count);
//#region Person
////PersonDB PDB = new PersonDB();
////Person p1 = new Person()
////{
////    FName = "Moshe",
////    LName = "CHOHEN",
////    TZ = "22222",
////    BirthDate = new DateTime(2000, 6, 7)
////};
////PDB.Insert(p1);
////PDB.SaveChanges();
//PersonDB PDB = new PersonDB();
//PersonList pLst = PDB.SelectAll();
//foreach (Person p in pLst)
//    Console.WriteLine(p.LName + p.BirthDate);
//Person person = pLst[0];
//person.BirthDate = new DateTime(2014, 9, 9);
//PDB.Insert(person);
//PDB.SaveChanges();
//Console.WriteLine( "after :");
//foreach (Person p in pLst)
//    Console.WriteLine(p.LName + p.BirthDate);
//#endregion
//#region City
//CityDB cDB = new CityDB();
////City c1 = new City() { CityName = "Nesher" };
////cDB.Insert(c1);
////cDB.SaveChanges();

//CityList cities = cDB.SelectAll();
//foreach (City c in cities)
//    Console.WriteLine(c.CityName);
//City cLast = cities.Last();
////cDB.Delete(cLast);
////cDB.SaveChanges();
////Console.WriteLine("delete :");
////cities = cDB.SelectAll();
////foreach (City c in cities)
////    Console.WriteLine(c.CityName);
//#endregion

//#region School
//SchoolDB sDb = new SchoolDB();

//School sc = new School() { SchoolCity = cLast, SchoolName = "רמבם1111" };
//sDb.Insert(sc);
//sDb.SaveChanges();
//SchoolList s = sDb.SelectAll();
//foreach (School c in s)
//    Console.WriteLine("schools " + c.SchoolName + " " + c.SchoolCity.CityName);
//School scLast = s.Last();
////sDb.Delete(scLast);
////sDb.SaveChanges();
////Console.WriteLine("delete :");
////s = sDb.SelectAll();
////foreach (School c in s)
////    Console.WriteLine(":)"+c.SchoolName + " " + c.SchoolCity.CityName);

//#endregion

//#region Student


//StudentDB sDB = new StudentDB();
//Student st = new Student() { BirthDate = new DateTime(2006, 12, 6),
//                            LName = "Golan", 
//                            FName = "Noaa",
//                            TZ = "9999",
//                            GetSchool = scLast };
//sDB.Insert(st);
//sDB.SaveChanges();
//StudentList sts = sDB.SelectAll();
//Console.WriteLine("students list before :");
//foreach (Student c in sts)
//    Console.WriteLine(c.FName + " " + c.TZ);
//Student sLast = sts.Last();
//sDB.Delete(sLast);
//sDB.SaveChanges();
//Console.WriteLine("delete :");
//sts = sDB.SelectAll();
//foreach (Student c in sts)
//    Console.WriteLine(c.FName + " " + c.TZ);

//#endregion
////#region
////UserDB uDB = new UserDB();
////UserList uList = uDB.SelectAll();
////foreach(User ur in uList)
////    Console.WriteLine(ur.UserName+" "+ur.UserCity.CityName);




////#endregion




////#region
////MemberDb mDb = new();
////MemberList mList = mDb.SelectAll();
////Console.WriteLine("Member "+mList.Count);
////Member m = new()
////{
////    NickName = "gugi",
////    TelNumber = "0589874133",
////    Pic = "C:\\Users\\nativ\\source\\repos\\HishtalmutMaui\\ViewModel\\Images\\boy2.webp"
////};


////mDb.Insert(m);
////int x1=mDb.SaveChanges();
////Console.WriteLine(x1);
////Member m1 = mList[0];
////m1.TelNumber = "0555555555";
////mDb.Update(m1);
////x1 = mDb.SaveChanges();
////Console.WriteLine(x1);
////#endregion
////#region
//////TEST GROUPTYPE
////GroupTypeDB gtDB = new();
////GroupTypeList gtList = gtDB.SelectAll();
////Console.WriteLine(gtList.Count);
////GroupType g = new GroupType() { Description = "אחר" };
////gtDB.Insert(g);
////int x = gtDB.SaveChanges();
////gtList = gtDB.SelectAll();
////Console.WriteLine("--" + gtList.Count);
////gtList.Last().Description = "משהו אחר";
////gtDB.Update(gtList.Last());
////x = gtDB.SaveChanges();
////gtList = gtDB.SelectAll();
////Console.WriteLine(gtList.Count);
////foreach (var item in gtList)
////    Console.WriteLine(item.Description + " " + item.Id);
////g = gtList.Last();
////gtDB.Delete(g);
////x = gtDB.SaveChanges();
////Console.WriteLine(x);
////#endregion

////#region
//////TEST GROUP
////GroupDB gDB = new();
////GroupList gList = gDB.SelectAll();
////Console.WriteLine("group:"+gList.Count);
////Group g1 = new Group()
////{
////    GroupEstablish = new DateTime(2021, 7, 11),
////    GroupName = "My graet family",
////    GroupTp= gtList.First(),
////    IdCreator = m1
////};
////gDB.Insert(g1);
////x = gDB.SaveChanges();
////Console.WriteLine(x);
////#endregion


Apiservice apiservice = new();
CityList cities=await apiservice.GetAllCities();
Console.WriteLine(cities.Count);
int id = cities.Last().Id;
await apiservice.DeleteACity(id);
Console.WriteLine(cities.Count);

City c1 = new City() { CityName = "בית אל" };
await apiservice.InsertACity(c1);
City myCity = cities.First();
myCity.CityName = "נתניה";
await apiservice.UpdateACity(myCity);

PersonList pList=await apiservice.GetAllPersons();
Console.WriteLine("Person List :"+pList[0]);
Person p = new Person() { BirthDate = new DateTime(12, 12, 12), FName = "fff", LName = "lll", TZ = "222" };
await apiservice.InsertAPerson(p);
pList = await apiservice.GetAllPersons();
Console.WriteLine("Person List :" + pList.Last());
pList[0].TZ = "0000000";
apiservice.UpdateAPerson(pList[0]);
pList = await apiservice.GetAllPersons();
Console.WriteLine("Person List :" + pList.Last());

Console.WriteLine();
