using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Badge_Repository
{
    public class BadgeRepo
    {
        private Dictionary<int, List<string>> _doorAccess = new Dictionary<int, List<string>>();

        public Dictionary<int, List<string>> GetDictionary()
        {
            return _doorAccess;
        }

        public bool DeleteDoor (int badgeid, string doorAccess)                               
        {
            List<string> doors = _doorAccess[badgeid];
            return doors.Remove(doorAccess);
        }

        public void CreateBadge (Badges badge)
        {
            _doorAccess.Add(badge.BadgeID, badge.DoorAccess);
        }

        public void UpdateBadge (int badgeid, string doorAccess)
        {
            List<string> doors = _doorAccess[badgeid];
            doors.Add(doorAccess);
        }

        public int ShowAll (int Dictionary)
        {
            return Dictionary;
        }
    }
}
