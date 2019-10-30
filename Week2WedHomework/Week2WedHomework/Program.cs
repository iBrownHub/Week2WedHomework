using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2WedHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            Bouldering bouldering = new Bouldering(9.3);
            Lead lead = new Lead();
            Gym gym = new Gym();
            Climbing[] climbings =
            {
                new Climbing(),
                new Roped(),
                new Bouldering(),
                new Lead(),
                new Climbing(9, 3, 1)
            };

            climbings[0].PrintGradeStyle();
            climbings[1].PrintGradeStyle();
            climbings[2].PrintGradeStyle();
            climbings[0].Indoor();
            climbings[1].Indoor();
            climbings[3].Indoor();
            Console.WriteLine(bouldering.Height);
            bouldering.Height = 20;
            Console.WriteLine(bouldering.Height);
            Console.WriteLine(climbings[4].ClimbsInSession());

            Console.ReadLine();

        }
    }

    class Climbing
    {
        //default constructor for Climbing
        public Climbing()
        {

        }
        public Climbing(bool hasChalk, string gradeValue)
        {
            chalk = hasChalk;
            grade = gradeValue;
        }

        public Climbing(int bouldersInSession, int ropedInSession, int leadInSession)
        {
            this.bouldersInSession = bouldersInSession;
            this.ropedInSession = ropedInSession;
            this.leadInSession = leadInSession;
        }
        private bool chalk;
        private string grade;
        private int climbsInSession;
        private int bouldersInSession;
        private int ropedInSession;
        private int leadInSession;
                
        public bool Chalk { get => chalk; set => chalk = value; }
        public string Grade { get => grade; set => grade = value; }

        public virtual void PrintGradeStyle()
        {
            Console.WriteLine("the grade style is Font");
        }
        public virtual void Indoor()
        {
            Console.WriteLine("I'm climbing");
        }
        public int ClimbsInSession()
        {
            climbsInSession = bouldersInSession + ropedInSession + leadInSession;
            return climbsInSession;
        }
    }

    class Roped : Climbing
    {        
        private bool rope;
        private bool belayDevice;
        private bool carabiner;
        public Roped()
        {

        }
        public Roped(bool hasRope, bool hasBelayDevice, bool hasCarabiner)
        {
            rope = hasRope;
            belayDevice = hasBelayDevice;
            carabiner = hasCarabiner;

        }
        public bool Rope { get => rope; set => rope = value; }
        public bool BelayDevice { get => belayDevice; set => belayDevice = value; }
        public bool Carabiner { get => carabiner; set => carabiner = value; }

        public override void PrintGradeStyle()
        {
            Console.WriteLine("The grade style is English");
        }
        public override void Indoor()
        {
            Console.WriteLine("I'm climbing indoors");
        }
    }

    class Bouldering : Climbing
    {
        public Bouldering()
        {

        }
        private double height;
        public Bouldering(double climbHeight)
        {
            height = climbHeight;
        }
        public override void PrintGradeStyle()
        {
            Console.WriteLine("The grade style is V grades");
        }

        public double Height { get => height; set => height = value; }
    }

    class Lead : Roped
    {
        public Lead()
        {

        }
        private bool quickdraw;
        public Lead(bool hasQuickdraw)
        {
            quickdraw = hasQuickdraw;
        }
        public override void Indoor()
        {
            Console.WriteLine("I'm climbing outdoors");
        }

        public bool Quickdraw { get => quickdraw; set => quickdraw = value; }
    }

    class Gym
    {
        private Bouldering bouldering;
        private Lead lead;

        internal Bouldering Bouldering { get => bouldering; set => bouldering = value; }
        internal Lead Lead { get => lead; set => lead = value; }
    }

    
}
