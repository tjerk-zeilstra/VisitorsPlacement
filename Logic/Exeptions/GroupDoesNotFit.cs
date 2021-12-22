using System;

namespace Logic.Exeptions
{
    public class GroupDoesNotFit : Exception
    {
        public GroupDoesNotFit() { }

        public GroupDoesNotFit(int max, int ammount) : base(string.Format("invalid ammount avilable chairs: {0} ammount added: {1}", max, ammount)){ }
    }
}
