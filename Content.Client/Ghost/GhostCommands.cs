using System;
using Content.Client.Administration;
using Content.Client.GameObjects.Components.Mobs;
using Content.Client.GameObjects.EntitySystems;
using Content.Client.UserInterface;
using Content.Shared.Administration;
using Content.Shared.GameObjects.Components.Mobs;
using Robust.Client.Console;
using Robust.Client.GameObjects;
using Robust.Client.Interfaces.Console;
using Robust.Client.Interfaces.GameObjects.Components;
using Robust.Client.Interfaces.GameObjects.Components.Interaction;
using Robust.Client.Interfaces.GameObjects.Components.Markers;
using Robust.Client.Interfaces.GameObjects.Components.UserInterface;
using Robust.Client.Interfaces.Graphics.ClientEye;
using Robust.Client.Interfaces.Input;
using Robust.Client.Interfaces.State;
using Robust.Client.Interfaces.UserInterface;
using Robust.Client.Player;
using Robust.Client.State;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.Interfaces.GameObjects;
using Robust.Shared.Interfaces.Network;
using Robust.Shared.Interfaces.Timing;
using Robust.Shared.IoC;
using Robust.Shared.Localization;
using Robust.Shared.Maths;
using Robust.Shared.Network;
using Robust.Shared.Timing;
using Robust.Shared.Utility;
using Robust.Shared.ViewVariables;

namespace Content.Client.Ghost
{
    public sealed class GhostCommands : IConsoleCommand
    {
        public string Command => "ghost";
        public string Description => "Makes you a ghost.";
        public string Help => "ghost";

        public void Execute(IConsoleShell shell, string argStr, string[] args)
        {
            var player = IoCManager.Resolve<IPlayerManager>().LocalPlayer;
            var ghostSystem = EntitySystem.Get<GhostSystem>();
            var ghost = ghostSystem.Player;
            if (ghost == null)
            {
                shell.WriteLine("You are not a ghost.");
                return;
            }

            ghostSystem.ToggleGhostVisibility();
            shell.WriteLine("You are now a ghost.");
        }

        [Command]
        public class PoopBananaCommand : IConsoleCommand
        {
            public string Command => "poopbanana";
            public string Description => "Makes the ghost poop out a banana.";
            public string Help => "poopbanana";

            public void Execute(IConsoleShell shell, string argStr, string[] args)
            {
                var player = IoCManager.Resolve<IPlayerManager>().LocalPlayer;
                var ghostSystem = EntitySystem.Get<GhostSystem>();
                var ghost = ghostSystem.Player;
                if (ghost == null)
                {
                    shell.WriteLine("You are not a ghost.");
                    return;
                }

                // Trigger the PoopBananaActionEvent.
                ghostSystem.RaiseLocalEvent(ghost.Owner.Uid, new PoopBananaActionEvent(player.AttachedEntity));
            }
        }
    }
}