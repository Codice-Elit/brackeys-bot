﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BrackeysBot
{
    public class UserDataCollection
    {
        [JsonPropertyName("users")]
        public List<UserData> Users { get; set; }

        public UserData GetUser(ulong id)
            => Users.FirstOrDefault(u => u.ID == id);
        public UserData CreateUser(ulong id)
        {
            UserData data = new UserData(id);
            Users.Add(data);
            return data;
        }
        public UserData GetOrCreate(ulong id)
            => GetUser(id) ?? CreateUser(id);

        public IEnumerable<UserData> GetUsersWithTemporalInfractions()
            => Users.Where(u => (u.TemporaryInfractions?.Count ?? 0) > 0);

    }
}