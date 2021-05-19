using Challenge_3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2.Repository
{
    public class BadgesRepo
    {

        private readonly Dictionary<int, List<string>> _badges = new Dictionary<int, List<string>>();
        
        //Create
        public bool AddBadgeToDictionary(Badges newBadge)
        {
            int startingCount = _badges.Count;

            _badges.Add(newBadge.BadgeID, newBadge.DoorNames);

            bool wasAddedCorrectly = (_badges.Count > startingCount) ? true : false;
            return wasAddedCorrectly;
        }

        //Read
        public Dictionary<int, List<string>> GetBadgeValuePairs()
        {
            return _badges;
        }

        //I suffered to get this just to let you know. lol
        public Dictionary<int, List<string>> GetBadgeValuePairsByBadgeID (int badgeID)
        {
            foreach (KeyValuePair<int, List<string>> badge in _badges)
            {
                if (badge.Key == badgeID)
                {
                    return _badges;
                }
            }
            return null;
        }

        //Update
        public bool AddDoorToBadge(int badgeID, Badges doorToBadge)
        {
            Dictionary<int, List<string>> oldbadge = GetBadgeValuePairsByBadgeID(badgeID);

            if (oldbadge != null)
            {
                oldbadge[badgeID] = doorToBadge.DoorNames;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
