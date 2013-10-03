using System;
using System.Drawing;

namespace RedGate.SIPFrameworkShared
{
    public interface IMenuService
    {
        IMenu MainMenu { get; }
        IMenu ToolsMenu { get; }
        IMenu RedGateMenu { get; }
    }

    public delegate TResult Function<in T, out TResult>(T arg);

    public interface IMenu
    {
        IMenu AddCommand(string commandName);
        IMenu AddCommand(string commandName, Image image);
        IMenu BeginSubmenu(string caption, string name);
        IMenu EndSubmenu();
        IMenu AddSeparator();

        /// <summary>
        /// Indicates that the item just added to the menu should have a separator before it.
        /// </summary>
        IMenu WithSeparatorBefore();

        //#region Insert position modification

        /// <summary>
        /// Specifies that the insert point should be placed before the specified index.
        /// If the specified index is &lt;= one, this is equivalent to calling AtStart().
        /// </summary>
        /// <param name="position">The one-based index at which the next operation should insert</param>
        IMenu Before(int position);

        /// <summary>
        /// Specifies that the insert point should be placed after the specified index.
        /// If the specified index is &gt;= the number of items currently in the menu, this is
        /// equivalent to calling AtEnd().
        /// </summary>
        /// <param name="position">The one-based index after which the next operation should insert</param>
        IMenu After(int position);

        /// <summary>
        /// Specifies that the insert point should be placed before a command with the specified name.
        /// If the requested command is not found, this has the same effect as calling 'AtStart()'.
        /// </summary>
        /// <remarks>
        /// Note that the details of available command names are implementation specific, although it is expected
        /// that this should at least be able to identify commands created by the same menu builder by the
        /// name specified in the 'AddCommand' method.
        /// </remarks>
        /// <param name="commandName">The command name to search for</param>
        IMenu Before(string commandName);

        /// <summary>
        /// Specifies that the insert point should be placed after a command with the specified name.
        /// If the requested command is not found, this has the same effect as calling 'AtEnd()'.
        /// </summary>
        /// <remarks>
        /// Note that the details of available command names are implementation specific, although it is expected
        /// that this should at least be able to identify commands created by the same menu builder by the
        /// name specified in the 'AddCommand' method.
        /// </remarks>
        /// <param name="commandName">The command name to search for</param>
        IMenu After(string commandName);

        /// <summary>
        /// Specifies that the insert point should be before the first entry in the current submenu.
        /// </summary>
        IMenu AtStart();

        /// <summary>
        /// Specifies that the insert point should be after the last entry in the current submenu.
        /// </summary>
        IMenu AtEnd();

        /// <summary>
        /// This method allows the menu building operation to be passed to another function
        /// without breaking the fluent method call chain, which means that chunks of the
        /// menu structure can be delegated to another function while still keeping the 
        /// entire structure clear.
        /// </summary>
        /// <example>
        /// IMenu BuildMainMenu(IMenu builder, Func<IMenu, IMenu> specialChunk)
        /// {
        ///     builder
        ///         .AddCommand("command1")
        ///         .BeginSubmenu("A Sub Menu", "Submenu1")
        ///             .BuildUsing(specialChunk)
        ///         .EndSubmenu()
        /// }
        /// </example>
        /// <param name="director">The function to call to build another part of the menu</param>
        IMenu BuildUsing(Function<IMenu, IMenu> director);
    }
}