// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace CommonLayer.Model
{
    internal class RequiredAttribute : Attribute
    {
        public string ErrorMessage;
    }
}