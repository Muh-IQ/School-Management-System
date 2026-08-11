using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Infrastructure.Common
{
    public static class HTMLBodys
    {
        public static string SendPasswordBody (string password)
        {
            return $"""
        <!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <title>Your Password</title>
        </head>

        <body style="
            margin: 0;
            padding: 0;
            background-color: #f4f6f8;
            font-family: Arial, Helvetica, sans-serif;
        ">

            <div style="
                width: 100%;
                padding: 40px 0;
            ">

                <div style="
                    max-width: 500px;
                    margin: 0 auto;
                    background-color: #ffffff;
                    border-radius: 12px;
                    padding: 35px;
                    box-sizing: border-box;
                    box-shadow: 0 4px 15px rgba(0, 0, 0, 0.08);
                ">

                    <div style="
                        text-align: center;
                        margin-bottom: 30px;
                    ">
                        <h1 style="
                            margin: 0;
                            color: #1f2937;
                            font-size: 26px;
                        ">
                            School Management System
                        </h1>

                        <p style="
                            color: #6b7280;
                            font-size: 14px;
                            margin-top: 8px;
                        ">
                            Account Information
                        </p>
                    </div>

                    <h2 style="
                        color: #1f2937;
                        font-size: 21px;
                        margin-bottom: 15px;
                    ">
                        Your Password
                    </h2>

                    <p style="
                        color: #4b5563;
                        font-size: 15px;
                        line-height: 1.6;
                    ">
                        Your password has been generated successfully.
                        You can use the password below to sign in to your account.
                    </p>

                    <div style="
                        background-color: #f3f4f6;
                        border: 1px solid #e5e7eb;
                        border-radius: 8px;
                        padding: 18px;
                        margin: 25px 0;
                        text-align: center;
                    ">

                        <p style="
                            margin: 0 0 8px 0;
                            color: #6b7280;
                            font-size: 13px;
                        ">
                            Your Password
                        </p>

                        <div style="
                            font-size: 22px;
                            font-weight: bold;
                            color: #111827;
                            letter-spacing: 2px;
                            word-break: break-word;
                        ">
                            {System.Net.WebUtility.HtmlEncode(password)}
                        </div>

                    </div>

                    <div style="
                        background-color: #fff7ed;
                        border-left: 4px solid #f97316;
                        padding: 12px 15px;
                        margin-top: 20px;
                    ">
                        <p style="
                            margin: 0;
                            color: #9a3412;
                            font-size: 13px;
                            line-height: 1.5;
                        ">
                            For your security, please do not share your password
                            with anyone.
                        </p>
                    </div>

                    <p style="
                        color: #9ca3af;
                        font-size: 12px;
                        line-height: 1.5;
                        text-align: center;
                        margin-top: 30px;
                    ">
                        If you did not request this password, please contact
                        the system administrator.
                    </p>

                    <hr style="
                        border: none;
                        border-top: 1px solid #e5e7eb;
                        margin: 25px 0;
                    ">

                    <p style="
                        color: #9ca3af;
                        font-size: 12px;
                        text-align: center;
                        margin: 0;
                    ">
                        © School Management System
                    </p>

                </div>

            </div>

        </body>
        </html>
        """;
        }

    }
}
