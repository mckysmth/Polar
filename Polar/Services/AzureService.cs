using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Polar.Model;

namespace Polar.Services
{
    public class AzureService
    {
        public async Task<bool> InsertNewUser(User user)
        {
            try
            {

                await App.MobileService.GetTable<User>().InsertAsync(user);
                App.user = user;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
      
        }
    }
}
