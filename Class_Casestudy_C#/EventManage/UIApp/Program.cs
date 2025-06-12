using DAL.DataAccess;
using DAL.Models;

namespace UIApp
{
    class Program
    {
        static void Main()
        {
            IUserInfoRepo<UserInfo> userRepo = new UserInfoRepo();
            UserInfoBL userBL = new UserInfoBL(userRepo);

            IEventDetailsRepo<EventDetails> eventRepo = new EventDetailsRepo();
            EventDetailsBL eventBL = new EventDetailsBL(eventRepo);

            ISessionInfoRepo<SessionInfo> sessionRepo = new SessionInfoRepo();
            SessionInfoBL sessionBL = new SessionInfoBL(sessionRepo);

            while (true)
            {
                Console.WriteLine("\n=== Main Menu ===");
                Console.WriteLine("1. UserInfo Operations");
                Console.WriteLine("2. EventDetails Operations");
                Console.WriteLine("3. SessionInfo Operations");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                var mainChoice = Console.ReadLine();

                switch (mainChoice)
                {
                    case "1":
                        Console.WriteLine("\n--- UserInfo ---");
                        Console.WriteLine("1. Register");
                        Console.WriteLine("2. Update");
                        Console.WriteLine("3. Delete");
                        Console.WriteLine("4. Validate");
                        Console.WriteLine("5. Get By Email");
                        Console.WriteLine("6. Get All");
                        Console.Write("Choice: ");
                        var uChoice = Console.ReadLine();
                        switch (uChoice)
                        {
                            case "1":
                                var newUser = new UserInfo { EmailId = "user1@gmail.com", UserName = "John", Password = "pass1234", Role = "Participant" };
                                Console.WriteLine(userBL.RegisterUser(newUser) ? "User Registered" : "Failed");
                                break;
                            case "2":
                                var updUser = new UserInfo { EmailId = "user1@gmail.com", UserName = "John", Password = "newpass", Role = "Participant" };
                                Console.WriteLine(userBL.UpdateUser(updUser) ? "User Updated" : "Failed");
                                break;
                            case "3":
                                Console.WriteLine(userBL.DeleteUser("user1@gmail.com") ? "User Deleted" : "Failed");
                                break;
                            case "4":
                                var validated = userBL.ValidateUser("user1@gmail.com", "newpass");
                                Console.WriteLine(validated != null ? "User Validated" : "Invalid Credentials");
                                break;
                            case "5":
                                var user = userBL.GetUserByEmail("user1@gmail.com");
                                Console.WriteLine(user != null ? $"{user.EmailId} - {user.UserName}" : "Not Found");
                                break;
                            case "6":
                                foreach (var usr in userBL.GetAllUsers())
                                    Console.WriteLine($"{usr.EmailId} - {usr.UserName}");
                                break;
                        }
                        break;

                    case "2":
                        Console.WriteLine("\n--- EventDetails ---");
                        Console.WriteLine("1. Add");
                        Console.WriteLine("2. Update");
                        Console.WriteLine("3. Delete");
                        Console.WriteLine("4. Get By ID");
                        Console.WriteLine("5. Get All");
                        Console.Write("Choice: ");
                        var eChoice = Console.ReadLine();
                        switch (eChoice)
                        {
                            case "1":
                                var newEvent = new EventDetails
                                {
                                    EventName = "TechFest",
                                    EventCategory = "Technology",
                                    EventDate = DateTime.Now.AddDays(10),
                                    Description = "Annual Tech Fest",
                                    Status = "Active"
                                };
                                Console.WriteLine(eventBL.AddEvent(newEvent) ? "Event Added" : "Failed");
                                break;
                            case "2":
                                var updEvent = new EventDetails
                                {
                                    EventId = 1,
                                    EventName = "TechExpo",
                                    EventCategory = "Innovation",
                                    EventDate = DateTime.Now.AddDays(15),
                                    Description = "Updated Description",
                                    Status = "Active"
                                };
                                Console.WriteLine(eventBL.UpdateEvent(updEvent) ? "Event Updated" : "Failed");
                                break;
                            case "3":
                                Console.WriteLine(eventBL.DeleteEvent(1) ? "Event Deleted" : "Failed");
                                break;
                            case "4":
                                var evt = eventBL.GetEventById(1);
                                Console.WriteLine(evt != null ? $"{evt.EventId} - {evt.EventName}" : "Not Found");
                                break;
                            case "5":
                                foreach (var ev in eventBL.GetAllEvents())
                                    Console.WriteLine($"{ev.EventId} - {ev.EventName}");
                                break;
                        }
                        break;

                    case "3":
                        Console.WriteLine("\n--- SessionInfo ---");
                        Console.WriteLine("1. Add");
                        Console.WriteLine("2. Update");
                        Console.WriteLine("3. Delete");
                        Console.WriteLine("4. Get By ID");
                        Console.WriteLine("5. Get By Event ID");
                        Console.WriteLine("6. Get All");
                        Console.Write("Choice: ");
                        var sChoice = Console.ReadLine();
                        switch (sChoice)
                        {
                            case "1":
                                var newSession = new SessionInfo
                                {
                                    EventId = 1,
                                    SessionTitle = "AI Practical",
                                    SpeakerId = 1,
                                    Description = "Deep Dive into AI",
                                    SessionStart = DateTime.Now.AddDays(10).AddHours(10),
                                    SessionEnd = DateTime.Now.AddDays(10).AddHours(12),
                                    SessionUrl = "http://new.com/session"
                                };
                                Console.WriteLine(sessionBL.AddSession(newSession) ? "Session Added" : "Failed");
                                break;
                            case "2":
                                var updSession = new SessionInfo
                                {
                                    SessionId = 1,
                                    EventId = 1,
                                    SessionTitle = "AI & ML",
                                    SpeakerId = 1,
                                    Description = "Updated Desc",
                                    SessionStart = DateTime.Now.AddDays(11),
                                    SessionEnd = DateTime.Now.AddDays(11).AddHours(2),
                                    SessionUrl = "http://example.com/session2"
                                };
                                Console.WriteLine(sessionBL.UpdateSession(updSession) ? "Session Updated" : "Failed");
                                break;
                            case "3":
                                Console.WriteLine(sessionBL.DeleteSession(1) ? "Session Deleted" : "Failed");
                                break;
                            case "4":
                                var sess = sessionBL.GetSessionById(4);
                                Console.WriteLine(sess != null ? $"{sess.SessionId} - {sess.SessionTitle}" : "Not Found");
                                break;
                            case "5":
                                var sessByEvent = sessionBL.GetSessionsByEventId(1);
                                foreach (var s in sessByEvent)
                                    Console.WriteLine($"{s.SessionId} - {s.SessionTitle}");
                                break;
                            case "6":
                                foreach (var s in sessionBL.GetAllSessions())
                                    Console.WriteLine($"{s.SessionId} - {s.SessionTitle}");
                                break;
                        }
                        break;

                    case "4":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
