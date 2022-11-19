using System;

namespace Flyweight
{
    public class Unit
    {
        private object texture;
        private string player;

        public Unit(object texture, string player)
        {
            this.texture = texture;
            this.player = player;
        }

        public void Move(ref int x,ref  int y, int xp, int yp)
        {
            int xold = x;
            int yold = y;
            x += xp;
            y += yp;
            Console.WriteLine($"moving player: {player} unit from coords: ({xold}, {yold}) to coords: ({x}, {y})");
        }

        public void DealDamage(ref int hp, int damage)
        {
            hp = hp - damage;
            Console.WriteLine($"unit health points equals now: {hp}");
        }

        public override string ToString()
        {
            return $"texture {texture}\nplayer: {player}";
        }
    }

    public class UnitFlyweight
    {
        private Unit sharedState;
        private int hp;
        private int x;
        private int y; 

        public UnitFlyweight(Unit sharedState, int hp, int x, int y)
        {
            this.sharedState = sharedState;
            this.hp = hp;
            this.x = x;
            this.y = y;
        }

        public void Move(int xp, int yp)
        {
            sharedState.Move(ref x,ref y, xp, yp);
        }

        public void DealDamage(int damage)
        {
            sharedState.DealDamage(ref hp, damage);
        }

        public void ShowResume()
        {
            Console.WriteLine($"{sharedState}\ncoords: ({x},{y})\nhp: {hp}");
        }
    }

    public class Knight : UnitFlyweight
    {
        public Knight(Unit sharedState, int x, int y) : base(sharedState, 100, x, y)
        {
        }
    }

    public class Villager : UnitFlyweight
    {
        public Villager(Unit sharedState, int x, int y) : base(sharedState, 25, x, y)
        {
        }
    }
    
    public class Canon : UnitFlyweight
    {
        public Canon(Unit sharedState, int x, int y) : base(sharedState, 500, x, y)
        {
        }
    }
}