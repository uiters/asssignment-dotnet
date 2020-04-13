
using System.Collections.Generic;

namespace lab_mvc_1.Models {
    public class Account {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class AccountData {
        public static List<Account> AccountList = new List<Account> () {
            new Account {UserName = "tom", Password = "123"},
            new Account {UserName = "jerry", Password = "123"}
        };
    }
}