using Database_demo;
using (ApplicationContext db = new ApplicationContext())
{
    var user = db.Users.FirstOrDefault(p => p.Name == "Pavel");
    Console.WriteLine(user?.Name);
    var ent = user.Enrollments.FirstOrDefault();
    Console.WriteLine(ent.UserId);
    ent.isCompleted = true;   
    db.SaveChanges();
}
//Operations.Add();
Operations.Print();

