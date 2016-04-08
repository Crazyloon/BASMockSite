using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.AspNet.Identity;

namespace BASMockSite.Models
{
    public class TestDataInitializer
    {
        private UserManager<ApplicationUser> _userManager;

        public TestDataInitializer(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public static async void Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();

            //if (await userManager.FindByEmailAsync("") == null)
            //{

            //}
            var role = await roleManager.FindByNameAsync("SiteAdmin");

            if (role == null)
            {
                roleManager.CreateAsync(new IdentityRole("SiteAdmin"));
            }
            

            if (!context.Colleges.Any())
            {
                //var ps = new List<ProgramStructures>
                //{
                //    // Create each program structure with an ID for the Program Entry it is related to.
                //    new ProgramStructures { Structure = CourseStructure.Daytime,  }, // 0
                //    new ProgramStructures { Structure = CourseStructure.Evening }, // 1
                //    new ProgramStructures { Structure = CourseStructure.FullTime }, // 2
                //    new ProgramStructures { Structure = CourseStructure.Hybrid }, // 3
                //    new ProgramStructures { Structure = CourseStructure.Online }, // 4
                //    new ProgramStructures { Structure = CourseStructure.PartTime }, // 5
                //    new ProgramStructures { Structure = CourseStructure.Daily } // 6
                //};

                ProgramStructure rtcPS1 = new ProgramStructure { ProgramEntryID = 1, Structure = CourseStructure.Evening, ProgramDuration = "6 Quarters", };
                ProgramStructure rtcPS2 = new ProgramStructure { ProgramEntryID = 1, Structure = CourseStructure.Hybrid, ProgramDuration = "6 Quarters", };

                //ps.ForEach(p => context.ProgramStructures.Add(p));
                //context.SaveChanges();

                ProgramEntry rtcFall = new ProgramEntry
                {
                    ApplicationDeadline = new DateTime(2016, 4, 1),
                    Season = EntrySeason.Fall,
                    DegreeID = 1
                    //Structures = { ps[1], ps[3] }
                };

                ProgramManager rtcSM = new ProgramManager
                {
                    Name = "Stefanie McIrvin",
                    Email = "smcirvin@rtc.edu",
                    Phone = "4253252352",
                    CollegeID = 1,
                };

                College rtc = new College
                {
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
                    Accredited = true,
                    Logo = File.ReadAllBytes("images//rtctemp.png")
                    //ProgramEntries = { rtcFall },
                    //ProgramManagers = { rtcSM }
                };

                Degree rtcBASAppDev = new Degree
                {
                    Name = "Application Development",
                    Description = "The Bachelor of Applied Science (BAS) in Application Development program at Renton Technical College is designed for students who are ready to take the next step toward a bachelor’s degree. The program includes technical courses in: data analysis, application and software development, programming, and project management. In addition to gaining a strong technical foundation, our program addresses the science, communications, and quantitative reasoning needed to work in this growing field. Students learn to work in teams, manage IT projects, and prepare software documentation. Graduates prepare for careers in a variety of occupations including: software development, computer systems analysis, web development, database analysis and mobile application development.",
                    AdmissionsSummary = "Admission is selective. Applications are due April 1st for the following fall entry. Applicants are notified by mail of a decision between late April and early May.",
                    ProgramURL = "http://www.rtc.edu/appdev",
                    ProgramManagerID = 1,
                    CollegeID = 1,
                    RequiredCredits = 90,
                    //College = rtc,
                    //ProgramManagers = rtcSM,
                    //ProgramEntries = { rtcFall }
                };

                //var rentonTech = context.College.Add(rtc).Entity;
                //var rtcManager = context.ProgramManagers.Add(rtcSM).Entity;
                //var rtcDeg = context.Degrees.Add(rtcBASAppDev).Entity;
                //var rtcEntry = context.ProgramEntries.Add(rtcFall).Entity;
                //var rtcStruct1 = context.ProgramStructures.Add(rtcPS1).Entity;
                //var rtcStruct2 = context.ProgramStructures.Add(rtcPS2).Entity;


                ////////////////////

                ProgramStructure bccPS1 = new ProgramStructure { ProgramEntryID = 2, Structure = CourseStructure.Daytime, ProgramDuration = "6 Quarters", };
                ProgramStructure bccPS2 = new ProgramStructure { ProgramEntryID = 2, Structure = CourseStructure.Daily, ProgramDuration = "6 Quarters", };

                ProgramEntry bccFall = new ProgramEntry
                {
                    ApplicationDeadline = new DateTime(2016, 4, 1),
                    Season = EntrySeason.Fall,
                    DegreeID = 2
                    //Structures = { ps[0], ps[6] },
                };

                ProgramManager bccSR = new ProgramManager
                {
                    Name = "Shanon Reedy",
                    Email = "shanon.reedy@bellevuecollege.edu",
                    Phone = "4255643189",
                    CollegeID = 2,
                };

                College bcc = new College
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
                    Accredited = true,
                    Logo = File.ReadAllBytes("images//bccTemp.png")
                    //ProgramEntries = { bccFall },
                    //ProgramManagers = { bccSR }
                };

                Degree bccDatAn = new Degree
                {
                    Name = "Data Analytics",
                    Description = "The Bachelor of Applied Science in Data Analytics provides graduates with the skills and knowledge needed for employment in the rapidly emerging field of data analytics, which comprises analyzing and interpreting the large datasets now available in a wide range of organizations and industries. Modern data analytics brings together tools and techniques from business, communication, graphic arts, information technology and statistics to collect, mine, interpret and represent large datasets to illustrate concepts and inform decisions.",
                    AdmissionsSummary = "Applications are available beginning each January for the following fall entry.",
                    ProgramURL = "http://www.bellevuecollege.edu/programs/degrees/bachelor/da/",
                    ProgramManagerID = 2,
                    CollegeID = 2,
                    RequiredCredits = 90,
                    //College = bcc,
                    //ProgramManagers = bccSR,
                    //ProgramEntries = { bccFall }
                };


                //var bellevueCC = context.College.Add(bcc).Entity;                
                //var bccManager = context.ProgramManagers.Add(bccSR).Entity;
                //var bccDeg = context.Degrees.Add(bccDatAn).Entity;
                //var bccEntry = context.ProgramEntries.Add(bccFall).Entity;                
                //var bccStruct1 = context.ProgramStructures.Add(bccPS1).Entity;
                //var bccStruct2 = context.ProgramStructures.Add(bccPS2).Entity;

                ////////////////////

                ProgramStructure grccPS1 = new ProgramStructure { ProgramEntryID = 3, Structure = CourseStructure.FullTime, ProgramDuration = "6 Quarters", };
                ProgramStructure grccPS2 = new ProgramStructure { ProgramEntryID = 3, Structure = CourseStructure.Daytime, ProgramDuration = "6 Quarters", };

                ProgramStructure grccPS3 = new ProgramStructure { ProgramEntryID = 4, Structure = CourseStructure.PartTime, ProgramDuration = "6 Quarters", };
                ProgramStructure grccPS4 = new ProgramStructure { ProgramEntryID = 4, Structure = CourseStructure.Evening, ProgramDuration = "6 Quarters", };

                ProgramEntry grccFall = new ProgramEntry
                {
                    ApplicationDeadline = new DateTime(2016, 4, 1),
                    Season = EntrySeason.Fall,
                    DegreeID = 3
                    //Structures = { ps[2], ps[0] },
                };

                ProgramEntry grccWint = new ProgramEntry
                {
                    ApplicationDeadline = new DateTime(2016, 4, 1),
                    Season = EntrySeason.Winter,
                    DegreeID = 3
                    //Structures = { ps[5], ps[1] }, //Parttime, evening
                };

                ProgramManager grccSC = new ProgramManager
                {
                    Name = "Sheila Capps",
                    Email = "scapps@greenriver.edu",
                    Phone = "2538339111",
                    CollegeID = 3,
                };

                College grcc = new College
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
                    Accredited = true,
                    Logo = File.ReadAllBytes("images//grccTemp.png")
                    //ProgramEntries = { grccFall, grccWint },
                    //ProgramManagers = { grccSC }
                };

                Degree grccNetAd = new Degree
                {
                    Name = "Network Administration and Security",
                    Description = "The bachelor's degree program in Network Administration and Security is designed to prepare students for employment as network and systems administrators, information security analysts, or computer support specialists.",
                    AdmissionsSummary = "Rolling Admissions, always accepting applications on a first come, first serve basis.",
                    ProgramURL = "http://www.greenriver.edu/academics/areas-of-study/bas-programs/network-administration-and-security.htm",
                    ProgramManagerID = 3,
                    CollegeID = 3,
                    RequiredCredits = 90,
                    //College = grcc,
                    //ProgramManagers = grccSC,
                    //ProgramEntries = { grccWint }
                };

                
                //var GreenRiverCC = context.College.Add(grcc).Entity;
                //var grccManager = context.ProgramManagers.Add(grccSC).Entity;                
                //var grccDeg = context.Degrees.Add(grccNetAd).Entity;
                //var grccEntryFall = context.ProgramEntries.Add(grccFall).Entity;
                //var grccEntryWint = context.ProgramEntries.Add(grccWint).Entity;
                //var grccStruct1 = context.ProgramStructures.Add(grccPS1).Entity;
                //var grccStruct2 = context.ProgramStructures.Add(grccPS2).Entity;

                ////////////////////

                ProgramStructure hlcPS1 = new ProgramStructure { ProgramEntryID = 5, Structure = CourseStructure.Daytime, ProgramDuration = "6 Quarters", };
                ProgramStructure hlcPS2 = new ProgramStructure { ProgramEntryID = 5, Structure = CourseStructure.Daily, ProgramDuration = "6 Quarters", };

                ProgramStructure hlcPS3 = new ProgramStructure { ProgramEntryID = 6, Structure = CourseStructure.Daytime, ProgramDuration = "6 Quarters", };
                ProgramStructure hlcPS4 = new ProgramStructure { ProgramEntryID = 6, Structure = CourseStructure.Daily, ProgramDuration = "6 Quarters", };

                ProgramEntry hlcFall = new ProgramEntry
                {
                    ApplicationDeadline = new DateTime(2016, 4, 1),
                    Season = EntrySeason.Fall,
                    DegreeID = 4
                    //Structures = { ps[0], ps[6] }, // CourseStructure.Daytime, CourseStructure.Daily
                };

                ProgramEntry hlcSpring = new ProgramEntry
                {
                    ApplicationDeadline = new DateTime(2016, 4, 1),
                    Season = EntrySeason.Spring,
                    DegreeID = 4
                    //Structures = { ps[0], ps[6] }, // CourseStructure.Daytime, CourseStructure.Daily
                };

                ProgramManager hlcTP = new ProgramManager
                {
                    Name = "Tanya Powers",
                    Email = "tpowers@highline.edu",
                    Phone = "2065923662",
                    CollegeID = 4,
                };

                College hlc = new College
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
                    Accredited = true,
                    Logo = File.ReadAllBytes("images//hlcTemp.jpg")
                    //ProgramEntries = { hlcFall, hlcSpring },
                    //ProgramManagers = { hlcTP }
                };

                Degree hlcCyberFor = new Degree
                {
                    Name = "Cybersecurity and Forensics",
                    Description = "In Highline's Computer Science and Computer Information Systems Department, you can prepare for a variety of information technology–related careers. Offering advanced topics and training, the department offers you the opportunity to become a computer programmer, network specialist, website/database developer, or data recovery and computer forensics specialist.",
                    AdmissionsSummary = "Applications are due each June 30th for the following fall and spring entry dates. After June 30, any remaining spaces will be filled with eligible applicants in the order received until the program is full.",
                    ProgramURL = "http://www.highline.edu/bas/cybersecurity/",
                    ProgramManagerID = 4,
                    CollegeID = 4,
                    RequiredCredits = 90,
                    //College = hlc,
                    //ProgramManagers = hlcTP,
                    //ProgramEntries = { hlcFall, hlcSpring }
                };


                //var highlineC = context.College.Add(hlc).Entity;
                //var hlcManager = context.ProgramManagers.Add(hlcTP).Entity;
                //var hlcDeg = context.Degrees.Add(hlcCyberFor).Entity;
                //var hlcEntryFall = context.ProgramEntries.Add(hlcFall).Entity;
                //var hlcEntrySpring = context.ProgramEntries.Add(hlcSpring).Entity;
                //var hlcStruct1 = context.ProgramStructures.Add(hlcPS1).Entity;
                //var hlcStruct2 = context.ProgramStructures.Add(hlcPS2).Entity;
                //var hlcStruct3 = context.ProgramStructures.Add(hlcPS3).Entity;
                //var hlcStruct4 = context.ProgramStructures.Add(hlcPS4).Entity;

                List<Image> imgList = new List<Image>
                {
                    new Image{
                        CollegeID = 1,
                        ImageURL = "~\\wwwroot\\uploads\\images\\pic1.jpg",
                    },
                    new Image
                    {
                        CollegeID = 1,
                        ImageURL = "~\\wwwroot\\uploads\\images\\pic2.jpg",
                    },
                    new Image
                    {
                        CollegeID = 1,
                        ImageURL = "~\\wwwroot\\uploads\\images\\pic3.jpg",
                    },
                    new Image
                    {
                        CollegeID = 1,
                        ImageURL = "~\\wwwroot\\uploads\\images\\pic4.jpg",
                    },
                    new Image
                    {
                        CollegeID = 1,
                        ImageURL = "~\\wwwroot\\uploads\\images\\pic5.jpg",
                    },
                    new Image
                    {
                        CollegeID = 2,
                        ImageURL = "~\\wwwroot\\uploads\\images\\pic6.jpg",
                    },
                    new Image
                    {
                        CollegeID = 2,
                        ImageURL = "~\\wwwroot\\uploads\\images\\pic7.jpg",
                    }
                };

                var rentonTech = context.Colleges.Add(rtc).Entity;
                var bellevueCC = context.Colleges.Add(bcc).Entity;
                var GreenRiverCC = context.Colleges.Add(grcc).Entity;
                var highlineC = context.Colleges.Add(hlc).Entity;

                context.SaveChanges();

                //
                imgList.ForEach(img => context.Images.Add(img));
                //

                var rtcManager = context.ProgramManagers.Add(rtcSM).Entity;
                var bccManager = context.ProgramManagers.Add(bccSR).Entity;
                var grccManager = context.ProgramManagers.Add(grccSC).Entity;
                var hlcManager = context.ProgramManagers.Add(hlcTP).Entity;

                context.SaveChanges();

                var rtcDeg = context.Degrees.Add(rtcBASAppDev).Entity;
                var bccDeg = context.Degrees.Add(bccDatAn).Entity;
                var grccDeg = context.Degrees.Add(grccNetAd).Entity;
                var hlcDeg = context.Degrees.Add(hlcCyberFor).Entity;

                context.SaveChanges();

                var rtcEntry = context.ProgramEntries.Add(rtcFall).Entity;
                var bccEntry = context.ProgramEntries.Add(bccFall).Entity;
                var grccEntryFall = context.ProgramEntries.Add(grccFall).Entity;
                var grccEntryWint = context.ProgramEntries.Add(grccWint).Entity;
                var hlcEntryFall = context.ProgramEntries.Add(hlcFall).Entity;
                var hlcEntrySpring = context.ProgramEntries.Add(hlcSpring).Entity;

                context.SaveChanges();

                var rtcStruct1 = context.ProgramStructures.Add(rtcPS1).Entity;
                var rtcStruct2 = context.ProgramStructures.Add(rtcPS2).Entity;
                var bccStruct1 = context.ProgramStructures.Add(bccPS1).Entity;
                var bccStruct2 = context.ProgramStructures.Add(bccPS2).Entity;
                var grccStruct1 = context.ProgramStructures.Add(grccPS1).Entity;
                var grccStruct2 = context.ProgramStructures.Add(grccPS2).Entity;
                var grccStruct3 = context.ProgramStructures.Add(grccPS3).Entity;
                var grccStruct4 = context.ProgramStructures.Add(grccPS4).Entity;
                var hlcStruct1 = context.ProgramStructures.Add(hlcPS1).Entity;
                var hlcStruct2 = context.ProgramStructures.Add(hlcPS2).Entity;
                var hlcStruct3 = context.ProgramStructures.Add(hlcPS3).Entity;
                var hlcStruct4 = context.ProgramStructures.Add(hlcPS4).Entity;


                context.SaveChanges();
            }
        }

    }
}
