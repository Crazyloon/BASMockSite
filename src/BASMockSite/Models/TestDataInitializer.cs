using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace BASMockSite.Models
{
    public class TestDataInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.School.Any())
            {
                var rtc = context.School.Add(
                    new School {
                        Name = "Renton Technical College",
                        Address = "3000 NE 4th Street",
                        City = "Renton",
                        State = "WA",
                        Zip = "98056",
                        MainPhone = "4252355840",
                        HomeWebAddress = "www.rtc.edu",
                        Description = "Renton Technical College, also known as RTC. It is a public two-year institution located in the Renton Highlands of Renton, Washington within the Seattle metropolitan area.",
                        County = "King",
                        Tuition = 14500m,
                        Degrees = new List<Degree>
                        {
                            new Degree
                            {
                                Title = "Application Development",
                                Description = "The Bachelor of Applied Science (BAS) in Application Development program at Renton Technical College is designed for students who are ready to take the next step toward a bachelor’s degree. The program includes technical courses in: data analysis, application and software development, programming, and project management. In addition to gaining a strong technical foundation, our program addresses the science, communications, and quantitative reasoning needed to work in this growing field. Students learn to work in teams, manage IT projects, and prepare software documentation. Graduates prepare for careers in a variety of occupations including: software development, computer systems analysis, web development, database analysis and mobile application development.",
                                ProgramDuration = "90 Credits, 6 Quarters",
                                Accreditated = true,
                                ProgramURL = "http://www.rtc.edu/appdev",
                                CourseModels = new List<CourseModel>
                                {
                                    new CourseModel
                                    {
                                        Structure = ModelType.Evening,
                                        EntryStructure = new ProgramEntry
                                        {
                                            ApplicationDeadline = new DateTime(2016, 4, 1),
                                            EntrySummary = "Admission is selective. Applications are due April 1st for the following fall entry. Applicants are notified by mail of a decision between late April and early May.",
                                            Season = EntrySeason.Fall
                                        }
                                    },
                                    new CourseModel
                                    {
                                        Structure = ModelType.Hybrid
                                    }
                                },
                                ProgramManager = new ProgramManager
                                {
                                    Name = "Stefanie McIrvin",
                                    Email = "smcirvin@rtc.edu"
                                }
                            }
                        }

                    }).Entity;

                var bcc = context.School.Add(
                    new School
                    {
                        Name = "Bellevue Community College",
                        Address = "3000 Landerholm Circle SE",
                        City = "Bellevue",
                        State = "WA",
                        Zip = "98007",
                        MainPhone = "4255641000",
                        HomeWebAddress = "www.bellevuecollege.edu",
                        Description = "Bellevue College is an open-access, community-based, public institution of higher education located in Bellevue, Washington, a city on the Eastside of Lake Washington, near Seattle.",
                        County = "King",
                        Tuition = 15000m,
                        Degrees = new List<Degree>
                        {
                            new Degree
                            {
                                Title = "Data Analytics",
                                Description = "The Bachelor of Applied Science in Data Analytics provides graduates with the skills and knowledge needed for employment in the rapidly emerging field of data analytics, which comprises analyzing and interpreting the large datasets now available in a wide range of organizations and industries. Modern data analytics brings together tools and techniques from business, communication, graphic arts, information technology and statistics to collect, mine, interpret and represent large datasets to illustrate concepts and inform decisions.",
                                ProgramDuration = "90 Credits, 6 Quarters",
                                Accreditated = true,
                                ProgramURL = "http://www.bellevuecollege.edu/programs/degrees/bachelor/da/",
                                CourseModels = new List<CourseModel>
                                {
                                    new CourseModel
                                    {
                                        Structure = ModelType.Daytime,
                                        EntryStructure = new ProgramEntry
                                        {
                                            EntrySummary = "Applications are available beginning each January for the following fall entry.",
                                            Season = EntrySeason.Fall
                                        }
                                    }
                                },
                                ProgramManager = new ProgramManager
                                {
                                    Name = "Shanon Reedy",
                                    Email = "shanon.reedy@bellevuecollege.edu"
                                }
                            }
                        }

                    }).Entity;

                var grcc = context.School.Add(
                    new School
                    {
                        Name = "Green River Community College",
                        Address = "12401 SE 320th Street",
                        City = "Auburn",
                        State = "WA",
                        Zip = "98092",
                        MainPhone = "2538339111",
                        HomeWebAddress = "www.greenriver.edu",
                        Description = "Green River College is a community college located in Auburn, Washington. It has a student body of approximately 10,000.",
                        County = "King",
                        Tuition = 15400m,
                        Degrees = new List<Degree>
                        {
                            new Degree
                            {
                                Title = "Network Administration and Security",
                                Description = "The bachelor's degree program in Network Administration and Security is designed to prepare students for employment as network and systems administrators, information security analysts, or computer support specialists.",
                                ProgramDuration = "90 Credits, 6 Quarters",
                                Accreditated = true,
                                ProgramURL = "http://www.greenriver.edu/academics/areas-of-study/bas-programs/network-administration-and-security.htm",
                                CourseModels = new List<CourseModel>
                                {
                                    new CourseModel
                                    {
                                        Structure = ModelType.Daytime,
                                        EntryStructure = new ProgramEntry
                                        {
                                            EntrySummary = "Rolling Admissions, always accepting applications on a first come, first serve basis.",
                                            Season = EntrySeason.Fall
                                        }
                                    },
                                    new CourseModel
                                    {
                                        Structure = ModelType.Evening,
                                        EntryStructure = new ProgramEntry
                                        {
                                            EntrySummary = "Rolling Admissions, always accepting applications on a first come, first serve basis.",
                                            Season = EntrySeason.Winter
                                        }
                                    }
                                },
                                ProgramManager = new ProgramManager
                                {
                                    Name = "Sheila Capps",
                                    Email = "scapps@greenriver.edu"
                                }
                            }
                        }

                    }).Entity;

                var hlc = context.School.Add(
                    new School
                    {
                        Name = "Highline College",
                        Address = "2400 S 240th St",
                        City = "Des Moines",
                        State = "WA",
                        Zip = "98198",
                        MainPhone = "2068783710",
                        HomeWebAddress = "www.highline.edu",
                        Description = "Highline College is an institution of higher education located in Des Moines, Washington, south of Seattle, Washington. Highline was founded in 1961 as the first community college in King County.",
                        County = "King",
                        Tuition = 15000m,
                        Degrees = new List<Degree>
                        {
                            new Degree
                            {
                                Title = "Cybersecurity and Forensics",
                                Description = "In Highline's Computer Science and Computer Information Systems Department, you can prepare for a variety of information technology–related careers. Offering advanced topics and training, the department offers you the opportunity to become a computer programmer, network specialist, website/database developer, or data recovery and computer forensics specialist.",
                                ProgramDuration = "90 Credits, 6 Quarters",
                                Accreditated = true,
                                ProgramURL = "http://www.highline.edu/bas/cybersecurity/",
                                CourseModels = new List<CourseModel>
                                {
                                    new CourseModel
                                    {
                                        Structure = ModelType.Daytime,
                                        EntryStructure = new ProgramEntry
                                        {
                                            ApplicationDeadline = new DateTime(2016, 6, 30),
                                            EntrySummary = "Applications are due each June 30th for the following fall and spring entry dates. After June 30, any remaining spaces will be filled with eligible applicants in the order received until the program is full.",
                                            Season = EntrySeason.Fall
                                        }
                                    },
                                    new CourseModel
                                    {
                                        Structure = ModelType.Daytime,
                                        EntryStructure = new ProgramEntry
                                        {
                                            ApplicationDeadline = new DateTime(2016, 6, 30),
                                            EntrySummary = "Applications are due each June 30th for the following fall and spring entry dates. After June 30, any remaining spaces will be filled with eligible applicants in the order received until the program is full.",
                                            Season = EntrySeason.Spring
                                        }
                                    }
                                },
                                ProgramManager = new ProgramManager
                                {
                                    Name = "Tanya Powers",
                                    Email = "tpowers@highline.edu"
                                }
                            }
                        }


                    }).Entity;               



                context.SaveChanges();
            }
        }

    }
}
