using System.Linq;
using _Project.Offers.Model;
using UnityEngine;

namespace _Project.Offers.View
{
    public class SpritesLoader : ISpritesLoader
    {
        public Sprite[] Execute(Resource[] resources) =>
            resources
                .Select(x => Execute(x.SpriteId))
                .ToArray();

        public Sprite Execute(string id) => 
            Resources.Load<Sprite>($"Sprites/{id}");
    }
}