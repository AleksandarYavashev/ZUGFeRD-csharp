/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace s2industries.ZUGFeRD
{
   /// <summary>
   /// Detailed information about a party that has a certain role within an invoice
   /// </summary>
   public class Party
   {
      /// <summary>
      /// Party identifier
      /// </summary>
      public string ID { get; set; }

      /// <summary>
      /// Party name, e.g. company name
      /// </summary>      
      public string Name { get; set; }

      /// <summary>
      /// Name of the contact at the party
      /// </summary>
      public string ContactName { get; set; }

      /// <summary>
      /// A name by which the
      /// Party is known, other
      /// than the Party name above (also
      /// known as Business name)
      /// </summary>      
      public string TradingName { get; set; }

      /// <summary>
      /// City, not including postcode (separate property)
      /// </summary>   
      public string City { get; set; }

      /// <summary>
      /// Party postcode, represented in the respective country format
      /// </summary>      
      public string Postcode { get; set; }

      /// <summary>
      /// Party country
      /// </summary>      
      public CountryCodes Country { get; set; }

      /// <summary>
      /// Street name and number
      /// </summary>
      public string Street { get; set; }

      /// XRechnung 2.1
      /// <summary>
      /// An additional address
      /// line in an address that
      /// can be used to give
      /// further details supplementing the main line.
      /// </summary>
      public string AddressLine2 { get; set; }

      /// XRechnung 2.1
      /// <summary>
      /// An additional address
      /// line in an address that
      /// can be used to give
      /// further details supplementing the main line.
      /// </summary>
      public string AddressLine3 { get; set; }
      public GlobalID GlobalID { get; set; }
   }
}
