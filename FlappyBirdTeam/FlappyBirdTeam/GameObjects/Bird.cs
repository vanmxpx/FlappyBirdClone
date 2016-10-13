using System;
using Microsoft.Xna.Framework;

namespace FlappyBirdTeam.GameObjects
{
    public class Bird : GameObject
    {
        public Bird(Single x, Single y, Single width, Single height)
            : base(x, y, width, height)
        {
            _velocity = new Vector2(0, 200.0f);
            _acceleration = new Vector2(0, 40.0f);
        }

        public override void Update(GameTime time)
        {
            _velocity += _acceleration;
            if (_velocity.Y > 800.0f)
                _velocity.Y = 800.0f;
            if (_position.Y > 800.0f)
                _position.Y = -_size.Y;
            else if (_position.Y < -_size.Y)
                _position.Y = 800.0f;
            base.Update(time);
        }

        protected override void OnTouch(Object sender, EventArgs e)
        {
            //_velocity.Y = -640.0f;
            _velocity.Y = -1000.0f;
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
