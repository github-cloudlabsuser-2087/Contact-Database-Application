using CRUD_application_2.Models;
using System;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>
       {
    new User { Id = 1001, Name = "Alice", Email = "alice@example.com" },
    new User { Id = 1002, Name = "Bob", Email = "bob@example.com" },
    new User { Id = 1003, Name = "Charlie", Email = "charlie@example.com" },
    new User { Id = 1004, Name = "Diana", Email = "diana@example.com" },
    new User { Id = 1005, Name = "Evan", Email = "evan@example.com" }
};
        //public static System.Collections.Generic.List<User> userlist = UserInitializer.InitializeUsers();

        // GET: User
        public ActionResult Index()
        {

            //userlist = UserInitializer.InitializeUsers();
            return View(userlist);
        }
 
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Find the user by ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If the user wasn't found, return a NotFound result (or similar)
            if (user == null)
            {
                return HttpNotFound();
            }

            // If the user was found, pass the user model to the view
            return View(user);
        }
 
        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }
 
        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                // Assuming _users is your data source for users, like a database or a static list
                // For demonstration, let's assume it's a static list
                userlist.Add(user); // Add the user to the list

                // In a real application, you would save the changes to your database here
                // dbContext.SaveChanges();

                return RedirectToAction("Index"); // Redirect to the index action to show the list of users
            }

            // If we got this far, something failed, redisplay form
            return View(user);
        
    }
 
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
            // Find the user by ID in the userlist
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If the user wasn't found, return a NotFound result (or similar)
            if (user == null)
            {
                return HttpNotFound();
            }

            // If the user was found, pass the user model to the Edit view
            return View(user);
        }
 
        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email")] int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
            var existingUser = userlist.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                // Update the user's details
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;

                // In a real application, you would save the changes to your database here
                // dbContext.SaveChanges();

                return RedirectToAction("Index"); // Redirect to the index action to show the list of users
            }
            else
            {
                return HttpNotFound(); // User not found
            }
            return View(user);
        }
 
        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Assuming _users is your data source for users, like a database or a static list
            // Find the user by ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If the user wasn't found, return a NotFound result (or similar)
            if (user == null)
            {
                return HttpNotFound();
            }

            // If the user was found, pass the user model to the Delete view
            return View(user);
        }
 
        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Find the user by ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                // Remove the user from the list
                userlist.Remove(user);

                // In a real application, you would save the changes to your database here
                // dbContext.Users.Remove(user);
                // dbContext.SaveChanges();
            }

            // Redirect to the index action to show the updated list of users
            return RedirectToAction("Index");
        }
    }
}
