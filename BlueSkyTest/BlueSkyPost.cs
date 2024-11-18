// Hindleware
// Copyright (c) 2024 Eric Hindle
// All rights reserved.
//
// Author Eric Hindle
//

using Bluesky.Net;
using Bluesky.Net.Commands.AtProto.Server;
using Bluesky.Net.Commands.Bsky.Feed;
using Bluesky.Net.Models;
using Bluesky.Net.Multiples;
using Microsoft.Extensions.DependencyInjection;


class BlueSkyPost
{
    static async Task Main(string[] args)

    {
        if (args.Length > 0)
        {
            string userName = "celebbirthdayuk.bsky.social";
            string password = "dkkblu55EH";
            int method = 1;
            if (args.Length > 1)
            {
                userName = args[1];
            }
            if (args.Length > 2)
            {
                password = args[2];
            }
            if (args.Length > 3)
            {
                _ = int.TryParse(args[3], out method);
            }
            string post_text = args[0].Replace("~", Environment.NewLine);

            if (method == 1)
            {
                await PostByXDotBluesky(post_text, userName, password);
            }
            else
            {
                await PostByBlueskyDotNet(post_text, userName, password);
            }
        }
    }

    static async Task PostByXDotBluesky(String post_text, String userName, String password)
    {
        X.Bluesky.BlueskyClient client = new(userName, password);
        await client.Post($"{post_text}"[..Math.Min(255, post_text.Length - 1)]);
        await Task.Delay(TimeSpan.FromSeconds(2), CancellationToken.None);
    }

    static async Task PostByBlueskyDotNet(String post_text, String userName, String password)
    {
        IServiceCollection services = new ServiceCollection();
        services.AddBluesky();
        await using var serviceProvider = services.BuildServiceProvider();
        var api = serviceProvider.GetRequiredService<IBlueskyApi>();
        Login command = new(userName, password);
        Multiple<Session, Error> result = await api.Login(command, CancellationToken.None);
        if (result.IsT1)
        {
            return;
        }

        CreatePost post = new($"{post_text}"[..Math.Min(255, post_text.Length - 1)]);
        await api.CreatePost(post, CancellationToken.None);
        await Task.Delay(TimeSpan.FromSeconds(2), CancellationToken.None);
    }

}
