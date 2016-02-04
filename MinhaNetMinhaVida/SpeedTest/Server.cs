/*
 * Minha Net Minha Vida
 * Copyright (C) 2016  Érycson Nóbrega <egdn2004@gmail.com>
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Xml.Serialization;

namespace MinhaNetMinhaVida.SpeedTest
{
    [Serializable]
    public class Server
    {
        [XmlAttribute("url")]
        public string Url;

        [XmlAttribute("lat")]
        public double Latitude;

        [XmlAttribute("lon")]
        public double Longitude;

        [XmlAttribute("name")]
        public string Name;

        [XmlAttribute("country")]
        public string Mountry;

        [XmlAttribute("cc")]
        public string CC;

        [XmlAttribute("sponsor")]
        public string Sponsor;

        [XmlAttribute("id")]
        public int ID;

        [XmlAttribute("host")]
        public string Host;
    }
}
