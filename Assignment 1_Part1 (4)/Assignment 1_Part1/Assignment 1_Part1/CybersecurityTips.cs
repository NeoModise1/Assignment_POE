using System;
using System.Collections.Generic;

namespace Assignment_1_Part1
{
    public class CybersecurityTips
    {
        private Dictionary<string, string> cyberTips = new Dictionary<string, string>()
        {
            {"vpn", "A VPN protects your privacy when using public WiFi."},
            {"2fa", "Two factor authentication adds an extra layer of protection."},
            {"scam", "Never trust messages asking for personal information."},
            // NEW: Expanded topics
            {"malware", "Malware is malicious software. Use antivirus and avoid untrusted downloads."},
            {"phishing", "Phishing tricks you into revealing sensitive info. Always verify senders."},
            {"password", "Strong passwords are essential. Use unique ones for each account."}
        };

        public string GetTip(string question)
        {
            foreach (var tip in cyberTips)
            {
                if (question.Contains(tip.Key))
                {
                    return tip.Value;
                }
            }

            return "I’m sorry, I didn’t quite understand that. Try asking about one of the following:\n- Password safety\n- Phishing\n- Malware\n- VPN\n- 2FA\nType 'EXIT' to quit.";
        }
    }
}
