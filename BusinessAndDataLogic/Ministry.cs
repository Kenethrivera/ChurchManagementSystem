using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAndDataLogic
{
    public enum Ministry
    {
        Discipleship,
        Prayer,
        Worship,
        ChristianEducation
    }
    public enum CRUDAction
    {
        View = 1,
        Add = 2,
        Update = 3,
        Delete = 4,
        Back = 5
    }

    public enum Worship
    {
        PraiseAndWorship = 1,
        SundayWorship = 2,
        Devotion = 3,
        Logout = 4
    }
}
