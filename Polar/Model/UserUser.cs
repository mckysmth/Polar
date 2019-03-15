using System;
namespace Polar.Model
{
    public class UserUser
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string UserFriendId { get; set; }

        public bool RequestCompleted { get; set; }

        public UserUser()
        {
            RequestCompleted = false;
        }
    }
}
