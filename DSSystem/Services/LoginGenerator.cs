using Microsoft.VisualBasic;

namespace DSSystem.Services
{
  class LoginGenerator
  {
    bool[] success = {true, false};
      string[] username = {
          "Anuk", "Palmer", "Jokovic", "Hazard", "Enzo", "Caicedo", "Lavia", "Cech", "Drogba", "Lamps", "Carvalho",
          "Mount", "Kante", "Reece", "Silva", "Chilwell", "Sterling", "Gusto", "Nkunku", "Broja",
          "Badiashile", "Gallagher", "Fofana", "James", "Petrov"
      };

      string[] password = {"Hello", "Test", "Password"}; // to be added 
      Random rnd = new Random();
        public List<LoginStruct> GenerateLogin()
        {
          Console.WriteLine("----------------");
          Console.WriteLine("Testing");
          //generating list of logins
          
          var loginList = new List<LoginStruct>();
          for (int i = 0 ; i < 9999; i++)
          {
            //int month  = rnd.Next(1, 13);
            int firstNameIndex  = rnd.Next(0, 25);
            int SecondNameIndex  = rnd.Next(0, 25);
            int passwordChoiceIndex = rnd.Next(0,3);
            //Console.WriteLine(passwordChoiceIndex);
            int SuccessChoice = rnd.Next(0,2);
            bool success = SuccessChoice == 0; //checking if SuccessChoice == 0, sets sucess true or false based on that
            // Console.WriteLine(firstName);
            // Console.WriteLine(SecondName);
            loginList.Add(new LoginStruct
            {
              Username =  $"{username[firstNameIndex] + username[SecondNameIndex]}",
              Password = $"{password[passwordChoiceIndex]}",
              DateTime =  DateTime.UtcNow,
              Success = success
            });
          }

          return loginList;
    }
  }
}