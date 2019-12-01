using Autofac;
using BLL.DTOEntities;
using BLL.Interfaces;
using BLL.Module;
using DAL.Interfaces;

namespace TestTool
{
    class Program
    {
        static void Main(string[] args)
        {
            //var uof = new UnitOfWork(new ApplicationContext());
            using (var container = ConfigurerBLL.ConfigureDependencies())
            {
                var uof = container.Resolve<IUnitOfWork>();
                var userService = container.Resolve<IUserService>();
                var postService = container.Resolve<IPostService>();
                //postService.SetLike(new LikeDTO {PostId = 3, UserId = 1});
                //userService.CreateUser(new UserDTO()
                //{
                //    Name = "Maks",
                //    Password = "Maks500",
                //    Surname = "Maks",
                //    Role = "Admin",
                //    Rating = 0,
                //    Email= "Maks@gmail.com",
                //});
                //var user = userService.GetUserById(1);
                //Console.WriteLine($"{user.Email}  {user.Password}  {user.GetType()}");

                //var x = userService.GetUserByEmailAndPass(user.Email, user.Password);

                //Console.WriteLine(x.GetType());

                //foreach (var userDto in userService.GetAll())
                //{
                //    Console.WriteLine($"{userDto.Name}  {userDto.Password}  {userDto.GetType()}");
                //}
            }



        }
    }
}
