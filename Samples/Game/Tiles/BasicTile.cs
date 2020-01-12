﻿using System;
using System.Collections.Generic;
using System.Text;
using GoRogue;
using SadConsole;
using SadRogue.Primitives;

namespace Game.Tiles
{
    class BasicTile : ColoredGlyph, GoRogue.IHasComponents
    {
        private GoRogue.ComponentContainer _components = new ComponentContainer();

        public Point Position { get; set; }

        public BasicTile(Color foreground, Color background, int glyph, Point position) : base(foreground, background, glyph) =>
            Position = position;

        public BasicTile(Point position) =>
            Position = position;

        #region Components
        public void AddComponent(object component)
        {
            if (!(component is ObjectComponents.ITileComponent)) throw new Exception($"Must add a {nameof(ObjectComponents.ITileComponent)} to this object");

            ((IHasComponents)_components).AddComponent(component);
            ((ObjectComponents.ITileComponent)component).Added(this);
        }

        public T GetComponent<T>()
        {
            return ((IHasComponents)_components).GetComponent<T>();
        }

        public IEnumerable<T> GetComponents<T>()
        {
            return ((IHasComponents)_components).GetComponents<T>();
        }

        public bool HasComponent(Type componentType)
        {
            return ((IHasComponents)_components).HasComponent(componentType);
        }

        public bool HasComponent<T>()
        {
            return ((IHasComponents)_components).HasComponent<T>();
        }

        public bool HasComponents(params Type[] componentTypes)
        {
            return ((IHasComponents)_components).HasComponents(componentTypes);
        }

        public void RemoveComponent(object component)
        {
            ((IHasComponents)_components).RemoveComponent(component);
            ((ObjectComponents.ITileComponent)component).Added(this);
        }

        public void RemoveComponents(params object[] components)
        {
            ((IHasComponents)_components).RemoveComponents(components);

            foreach (var item in components)
                ((ObjectComponents.ITileComponent)item).Added(this);
        }
    #endregion
    }
}
