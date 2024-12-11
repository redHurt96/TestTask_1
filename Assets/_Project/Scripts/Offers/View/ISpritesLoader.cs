using _Project.Offers.Model;
using UnityEngine;

namespace _Project.Offers.View
{
    public interface ISpritesLoader
    {
        Sprite[] Execute(Resource[] resources);
        Sprite Execute(string id);
    }
}