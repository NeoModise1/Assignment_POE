using System;
using System.Media;
using System.Threading;
using System.Collections.Generic;
using static System.Console;

namespace Assignment_1_Part1
{
    internal class Chatbot
    {
        private string userName;
        private int questionCount = 0;
        Random rand = new Random();

        // Dictionary for specific cybersecurity tips
        Dictionary<string, string> cyberTips = new Dictionary<string, string>()
        {
            {"vpn", "A VPN protects your privacy when using public WiFi by encrypting your connection, preventing others from seeing what you're doing online."},
            {"2fa", "Two-factor authentication (2FA) adds an extra layer of protection to your accounts, requiring not just a password but also a code sent to your phone or email."},
            {"scam", "Be cautious with unsolicited emails or messages asking for personal information. Legitimate companies will never ask for sensitive data this way."},
            {"privacy", "Always review your account security settings to protect your privacy."}
        };

        // Default responses for unknown questions
        string[] unknownResponses =
        {
            "Try asking about passwords.",
            "Ask about phishing.",
            "I can explain malware.",
            "Try cybersecurity topics.",
            "Ask how to stay safe online."
        };

        // NEW: Memory storage for personalization
        private Dictionary<string, string> memory = new Dictionary<string, string>();

        // Main entry point to start the application
        public void StartApplication()
        {
            SetupConsole();
            PlayVoiceGreeting();
            DisplayLogo();
            DisplayWelcomeMessage();
            GetUserName();
            StartConversation();
            ExitMessage();
        }

        // Console setup
        private void SetupConsole()
        {
            Title = "Cybersecurity Awareness Bot";
            Clear();
        }

        // Displaying the chatbot logo
        private void DisplayLogo()
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("  ██████ Cybersecurity Awareness Bot ██████");
            ResetColor();
        }

        // Play the initial greeting sound
        public void PlayVoiceGreeting()
        {
            try
            {
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("Playing greeting audio...");
                ResetColor();

                SoundPlayer player = new SoundPlayer("Voice 1.wav"); // WAV playback
                player.PlaySync();

                Console.Clear();
            }
            catch
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Audio could not play.");
                ResetColor();
            }
        }

        // Displaying the initial welcome message
        private void DisplayWelcomeMessage()
        {
            ForegroundColor = ConsoleColor.Green;
            TypeWriterEffect("Welcome to the Cybersecurity Awareness Bot");
            TypeWriterEffect("I help you stay safe online");
            TypeWriterEffect("This chatbot promotes cybersecurity awareness.");
            TypeWriterEffect("Type HELP to see topics.");
            ResetColor();
        }

        // Get the user's name for personalized experience
        public void GetUserName()
        {
            ForegroundColor = ConsoleColor.Yellow;
            Write("Enter your name: ");
            ResetColor();
            userName = ReadLine();
            while (string.IsNullOrWhiteSpace(userName))
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Invalid input. Please enter a valid name.");
                ResetColor();
                Write("Enter name: ");
                userName = ReadLine();
            }
            userName = FormatName(userName);

            // NEW: Store name in memory
            Remember("name", userName);

            ForegroundColor = ConsoleColor.Green;
            WriteLine("Welcome " + userName);
            ResetColor();
        }

        // Start the conversation with the user
        private void StartConversation()
        {
            string question = "";
            while (question != "exit")
            {
                WriteLine();
                DrawLine();
                ForegroundColor = ConsoleColor.DarkYellow;
                WriteLine("Tip : Type 'exit' when you are done asking questions.");
                ResetColor();

                ForegroundColor = ConsoleColor.Yellow;
                Write(userName + ": ");
                ResetColor();
                question = ReadLine()?.ToLower();
                if (string.IsNullOrWhiteSpace(question))
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Input cannot be empty.");
                    ResetColor();
                    continue;
                }
                questionCount++;
                Respond(question);
            }
        }

        // Respond to user's questions
        private void Respond(string question)
        {
            ForegroundColor = ConsoleColor.Cyan;
            Write("Bot: ");
            ResetColor();

            // NEW: Sentiment handling
            if (question.Contains("worried") || question.Contains("stressed"))
            {
                TypeWriterEffect("I understand how you feel. Let’s take it step by step.");
                return;
            }
            if (question.Contains("happy") || question.Contains("excited"))
            {
                TypeWriterEffect("That’s great to hear! Keep it up!");
                return;
            }
            if (question.Contains("sad") || question.Contains("upset"))
            {
                TypeWriterEffect("I’m sorry you feel that way. Talking it through might help.");
                return;
            }

            // NEW: Memory recall
            if (question.Contains("what is my name"))
            {
                TypeWriterEffect("Your name is " + Recall("name"));
                return;
            }
            if (question.Contains("when is my birthday"))
            {
                TypeWriterEffect("Your birthday is " + Recall("birthday"));
                return;
            }

            // Existing responses
            if (question.Contains("how are you"))
            {
                TypeWriterEffect("I am functioning perfectly and ready to help. How can I assist you with your cybersecurity concerns?");
            }
            else if (question.Contains("purpose"))
            {
                TypeWriterEffect("My purpose is to provide cybersecurity education and promote awareness about various online security threats, helping you stay safe in the digital world.");
            }
            else if (question.Contains("safe browsing"))
            {
                TypeWriterEffect("Safe browsing means using the internet carefully by avoiding suspicious websites, not clicking unknown links, and ensuring websites are secure (https). Always keep your browser updated and be cautious when downloading files.");
            }
            else if (question.Contains("malware"))
            {
                TypeWriterEffect("Malware is malicious software designed to damage, disrupt, or gain unauthorized access to a computer system. It includes viruses, worms, and spyware. Always use antivirus software and avoid downloading files from untrusted sources.");
            }
            else if (question.Contains("social engineering"))
            {
                TypeWriterEffect("Social engineering is a manipulation technique where attackers trick people into giving away confidential information. This can happen through phone calls, emails, or messages pretending to be trustworthy sources. Always verify identities before sharing information.");
            }
            else if (question.Contains("cybersecurity"))
            {
                TypeWriterEffect("Cybersecurity refers to the practice of protecting computers, networks, and data from unauthorized access, attacks, or damage. It includes using strong passwords, firewalls, encryption, and safe online behavior.");
            }
            else if (question.Contains("password"))
            {
                // NEW: Play WAV when password is mentioned
                try
                {
                    SoundPlayer player = new SoundPlayer("Voice 1.wav");
                    player.Play();
                }
                catch { }

                TypeWriterEffect("Passwords are the first line of defense against cyberattacks. A strong password includes a mix of uppercase and lowercase letters, numbers, and symbols. Use different passwords for each of your accounts and enable multi-factor authentication (MFA) to enhance security.");
            }
            else if (question.Contains("phishing"))
            {
                TypeWriterEffect("Phishing is when attackers try to trick you into revealing sensitive information like passwords, social security numbers, or bank account details. Be cautious of unsolicited emails or messages, and always verify the sender's authenticity before clicking on links or downloading attachments.");
            }
            else if (question.Contains("help"))
            {
                TypeWriterEffect("Here are some topics you can ask about:\n- Password safety\n- Phishing\n- Malware\n- Safe browsing\n- Social engineering\n- VPN\n- 2FA (Two-Factor Authentication)\nType 'exit' to quit.");
            }
            else if (question.StartsWith("my birthday is"))
            {
                string birthday = question.Substring(14).Trim();
                Remember("birthday", birthday);
                TypeWriterEffect($"Got it! I’ll remember your birthday is {birthday}.");
            }
            else if (question == "exit")
            {
                TypeWriterEffect($"Goodbye {userName}! Stay safe online!");
            }
            else
            {
                TypeWriterEffect(unknownResponses[rand.Next(unknownResponses.Length)]);
            }
        }

        // Display exit message
        private void ExitMessage()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Thank you for using the chatbot. Stay safe and informed!");
            ResetColor();
        }

        // Typewriter effect for displaying text
        private void TypeWriterEffect(string text)
        {
            foreach (char letter in text)
            {
                Write(letter);
                Thread.Sleep(20);
            }
            WriteLine();
        }

        // Draw a line to separate outputs for clarity
        private void DrawLine()
        {
            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine("-------------------------------------------------");
            ResetColor();
        }

        // Format name with proper capitalization
        private string FormatName(string name)
        {
            return char.ToUpper(name)
                        // Format name with proper capitalization
        private string FormatName(string name)
        {
            return char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }

        // NEW: Memory helpers
        public void Remember(string key, string value)
        {
            if (!memory.ContainsKey(key))
                memory.Add(key, value);
            else
                memory[key] = value;
        }

        public string Recall(string key)
        {
            return memory.ContainsKey(key) ? memory[key] : "I don’t remember that yet.";
        }
    }

}
