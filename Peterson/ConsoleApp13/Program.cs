namespace Peterson
{
    using System;
    using System.Threading;

    class Program
    {

    }

    public class SimplePetersonLock
    {
        private bool[] want = new bool[2];
        private int turn;

        public void Lock(int myId)
        {
            int other = 1 - myId;
            want[myId] = true;
            turn = other;

            while (want[other] && turn == other) { }
        }

        public void Unlock(int myId)
        {
            want[myId] = false;
        }
    }
    public class BrokenPetersonLock
    {
        private bool[] want = new bool[2];  
        private int turn;                   

        public void Lock(int myId)
        {
            int other = 1 - myId;
            want[myId] = true;

            while (want[other] && turn == other) { }
            turn = other;
        }

        public void Unlock(int myId)
        {
            want[myId] = false;
        }
    }
}
