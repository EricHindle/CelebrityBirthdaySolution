// Hindleware
// Copyright (c) 2024 Eric Hindle
// All rights reserved.
//
// Author Eric Hindle
//

class BlueSkyPost
{
    static async Task Main(string[] args)

    {
        string userName = "celebbirthdayuk.bsky.social";
        string password = "dkkblu55EH";
        X.Bluesky.BlueskyClient client = new(userName, password);
        string post_text = args[0].Replace("~", Environment.NewLine);
        await client.Post($"{post_text}");
    }
}
