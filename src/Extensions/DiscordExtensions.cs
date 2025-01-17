﻿namespace iPhoneController.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DSharpPlus;
    using DSharpPlus.Entities;

    using iPhoneController.Configuration;
    using iPhoneController.Diagnostics;

    public static class DiscordExtensions
    {
        private static readonly IEventLogger _logger = EventLogger.GetLogger("DISCORD_EXT");

        public static async Task<DiscordMessage> SendDirectMessage(this DiscordClient client, DiscordUser user, DiscordEmbed embed)
        {
            if (embed == null)
                return null;

            return await client.SendDirectMessage(user, string.Empty, embed);
        }

        public static async Task<DiscordMessage> SendDirectMessage(this DiscordClient client, DiscordUser user, string message, DiscordEmbed embed)
        {
            try
            {
                var dm = await client.CreateDmAsync(user);
                if (dm != null)
                {
                    var msg = await dm.SendMessageAsync(message, false, embed);
                    return msg;
                }
            }
            catch (Exception)
            {
                //_logger.Error(ex);
                _logger.Error($"Failed to send DM to user {user.Username}.");
            }

            return null;
        }

        public static bool HasRequiredRoles(this DiscordMember member, List<DiscordConfig> servers)
        {
            foreach (var server in servers)
            {
                if (server.RequiredRoles.Count == 0)
                    return true;

                var memberRoles = member.Roles?.Select(x => x.Id)?.ToList();
                if (memberRoles == null)
                    continue;

                if (server.RequiredRoles.Any(x => memberRoles.Contains(x)))
                    return true;
            }
            return false;
        }

        public static bool IsValidChannel(this ulong channelId, List<DiscordConfig> servers)
        {
            foreach (var server in servers)
            {
                // If no channel id is specified allow the command to execute in all channels, otherwise only the channel specified.
                if (server.ChannelIds.Count == 0 || server.ChannelIds.Contains(channelId))
                    return true;
            }
            return false;
        }
    }
}
