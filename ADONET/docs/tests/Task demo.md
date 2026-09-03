# Білет 6


	1. EF Data Annotations
	2. EF Query Data
	3. EF Core Save Data
	4. Створити базу шкільної ієрархії.
		○ Школа, Клас, Учень, Викладач. 
		○ Де відобразити відношення:
			§  учень-викладачі
			§ Викладач учні
			§ Викладач класи
	
	
Звісно, ось приклад реалізації моделей для шкільної ієрархії в Entity Framework Core:

```csharp
public class School
{
    public int SchoolId { get; set; }
    public string Name { get; set; }
    public ICollection<Class> Classes { get; set; }
}

public class Class
{
    public int ClassId { get; set; }
    public string Name { get; set; }
    public int SchoolId { get; set; }
    public School School { get; set; }
    public ICollection<Student> Students { get; set; }
    public ICollection<TeacherClass> TeacherClasses { get; set; }
}

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int ClassId { get; set; }
    public Class Class { get; set; }
    public ICollection<StudentTeacher> StudentTeachers { get; set; }
}

public class Teacher
{
    public int TeacherId { get; set; }
    public string Name { get; set; }
    public ICollection<StudentTeacher> StudentTeachers { get; set; }
    public ICollection<TeacherClass> TeacherClasses { get; set; }
}

// Проміжна таблиця для відношення багато-до-багатьох між Учнями та Викладачами
public class StudentTeacher
{
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
}

// Проміжна таблиця для відношення багато-до-багатьох між Викладачами та Класами
public class TeacherClass
{
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public int ClassId { get; set; }
    public Class Class { get; set; }
}

public class SchoolContext : DbContext
{
    public DbSet<School> Schools { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Встановлення первинних ключів
        modelBuilder.Entity<School>().HasKey(s => s.SchoolId);
        modelBuilder.Entity<Class>().HasKey(c => c.ClassId);
        modelBuilder.Entity<Student>().HasKey(s => s.StudentId);
        modelBuilder.Entity<Teacher>().HasKey(t => t.TeacherId);

        // Встановлення відношень багато-до-багатьох
        modelBuilder.Entity<StudentTeacher>()
            .HasKey(st => new { st.StudentId, st.TeacherId });
        modelBuilder.Entity<StudentTeacher>()
            .HasOne(st => st.Student)
            .WithMany(s => s.StudentTeachers)
            .HasForeignKey(st => st.StudentId);
        modelBuilder.Entity<StudentTeacher>()
            .HasOne(st => st.Teacher)
            .WithMany(t => t.StudentTeachers)
            .HasForeignKey(st => st.TeacherId);

        modelBuilder.Entity<TeacherClass>()
            .HasKey(tc => new { tc.TeacherId, tc.ClassId });
        modelBuilder.Entity<TeacherClass>()
            .HasOne(tc => tc.Teacher)
            .WithMany(t => t.TeacherClasses)
            .HasForeignKey(tc => tc.TeacherId);
        modelBuilder.Entity<TeacherClass>()
            .HasOne(tc => tc.Class)
            .WithMany(c => c.TeacherClasses)
            .HasForeignKey(tc => tc.ClassId);
    }
}
```

Цей код демонструє базову структуру моделей та їх відношень у базі даних. Ви можете налаштувати ці моделі відповідно до ваших потреб, додавши додаткові властивості та методи. Також важливо врахувати валідацію даних та логіку бізнес-правил, які можуть бути імплементовані в цих моделях. Після створення моделей, ви можете використовувати міграції EF Core для генерації бази даних та управління її схемою.