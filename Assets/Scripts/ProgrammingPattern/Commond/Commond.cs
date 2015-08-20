using System.Collections;
using UnityEngine;

namespace AllTheDemo.ProgrammingPattern.Commond
{
    public class Commond
    {
        public virtual void excute(Animator ani)
        {
 
        }
    }

    public class JumpCommnod : Commond
    {
        public override void excute(Animator ani)
        {

        }
    }

    public class FireGunCommnod : Commond
    {
        public virtual void excute(Animator ani)
        {

        }
    }

    public class SneakCommnod : Commond
    {
        public override void excute(Animator ani)
        {

        }
    }

    public class ShoutCommnod : Commond
    {
        public override void excute(Animator ani)
        {

        }
    }
}