﻿namespace SadConsole.Effects
{
    /// <summary>
    /// The interface describing a cell effect
    /// </summary>
    public interface ICellEffect// : System.IEquatable<ICellEffect>
    {
        /// <summary>
        /// True when the effect is finished.
        /// </summary>
        bool IsFinished { get; }

        /// <summary>
        /// Flags this effect to be cloned when assigned to a cell instead of reused.
        /// </summary>
        bool CloneOnAdd { get; set; }

        /// <summary>
        /// A delay applied to the effect only when it first runs.
        /// </summary>
        double StartDelay { get; set; }

        /// <summary>
        /// When true, the effect should be disassociated with cells when it has finished processing.
        /// </summary>
        bool RemoveOnFinished { get; set; }

        /// <summary>
        /// When <see langword="true"/>, indicates the <see cref="EffectsManager"/> should restore the cell to its original state.
        /// </summary>
        bool RestoreCellOnRemoved { get; set; }

        /// <summary>
        /// Applies the state of the effect to a cell.
        /// </summary>
        /// <param name="cell">The surface cell using this effect.</param>
        /// <param name="originalState">The state of the cell prior to the effect being applied.</param>
        bool ApplyToCell(ColoredGlyph cell, EffectsManager.ColoredGlyphState originalState);

        /// <summary>
        /// Updates the state of the effect.
        /// </summary>
        /// <param name="gameTimeSeconds">Time since the last call to this effect.</param>
        void Update(double gameTimeSeconds);

        /// <summary>
        /// Restarts the cell effect.
        /// </summary>
        void Restart();

        /// <summary>
        /// Returns a duplicate of this effect.
        /// </summary>
        /// <returns>A new copy of this effect.</returns>
        ICellEffect Clone();
    }
}
