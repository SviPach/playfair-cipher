using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace playfair
{
    public partial class Form1 : Form
    {

        public enum Language
        {
            English,
            Czech,
            CzechSmall
        }
        private Language language = Language.English;

        Dictionary<int, string> numbers_en = new Dictionary<int, string>()
        {
            { 0, "XZEROX" },
            { 1, "XONEX" },
            { 2, "XTWOX" },
            { 3, "XTHREX" },
            { 4, "XFOURX" },
            { 5, "XFIVEX" },
            { 6, "XSIX" },
            { 7, "XSEVENX" },
            { 8, "XEIGHTX" },
            { 9, "XNINEX" }
        };
        
        Dictionary<int, string> numbers_cz = new Dictionary<int, string>()
        {
            { 0, "XZEROX" },
            { 1, "XONEX" },
            { 2, "XTVOX" },
            { 3, "XTHREX" },
            { 4, "XFOURX" },
            { 5, "XFIVEX" },
            { 6, "XSIX" },
            { 7, "XSEVENX" },
            { 8, "XEIGHTX" },
            { 9, "XNINEX" }
        };

        private char[,] englishTable =
        {
            { 'A', 'B', 'C', 'D', 'E' },
            { 'F', 'G', 'H', 'I', 'K' },
            { 'L', 'M', 'N', 'O', 'P' },
            { 'Q', 'R', 'S', 'T', 'U' },
            { 'V', 'W', 'X', 'Y', 'Z' }
        };
        
        private char[,] czechTable =
        {
            { 'A', 'Á', 'B', 'C', 'Č', 'D', 'Ď', 'E' },
            { 'É', 'Ě', 'F', 'G', 'H', 'I', 'Í', 'J' },
            { 'K', 'L', 'M', 'N', 'Ň', 'O', 'Ó', 'P' },
            { 'Q', 'R', 'Ř', 'S', 'Š', 'T', 'Ť', 'U' },
            { 'Ú', 'Ů', 'V', 'X', 'Y', 'Ý', 'Z', 'Ž' }
        };
        
        private char[,] czechSmallTable =
        {
            { 'A', 'B', 'C', 'D', 'E' },
            { 'F', 'G', 'H', 'I', 'J' },
            { 'K', 'L', 'M', 'N', 'O' },
            { 'P', 'Q', 'R', 'S', 'T' },
            { 'U', 'V', 'X', 'Y', 'Z' }
        };

        public Form1()
        {
            InitializeComponent();
            char[,] tableOriginal;
            if (language == Language.English) { tableOriginal = englishTable; }
            else if (language == Language.Czech){ tableOriginal = czechTable; }
            else {tableOriginal = czechSmallTable; }

            int i_max, j_max;
            if (language == Language.English || language == Language.CzechSmall) { i_max = j_max = 5; }
            else
            {
                i_max = 5;
                j_max = 8;
            }
            for (int i = 0; i < i_max; i++) // Original table output
            {
                for (int j = 0; j < j_max; j++)
                {
                    textBox_encrypted_table.Text += tableOriginal[i, j];
                    textBox_encrypted_table.Text += ' ';
                }

                textBox_encrypted_table.Text += Environment.NewLine;
            }

            button_language_en.Enabled = false;
            label_language.Text = "Current language: English";
            
            button_keyword_change.Enabled = false;
            button_text_Encrypt.Enabled = false;
            button_text_Decrypt.Enabled = false;
        }

        private void button_keyword_Click(object sender, EventArgs e)
        {
            string keyword = textBox_keyword.Text;
            string keywordFiltered;
            if (language == Language.English) { keywordFiltered = Keyword_Filter_EN(keyword); }
            else if (language == Language.Czech) { keywordFiltered = Keyword_Filter_CZ(keyword); }
            else {keywordFiltered = Keyword_Filter_CZ_small(keyword); ;}
            

            char[,] charsEncrypted;
            if (language == Language.English) { charsEncrypted = Generate_Table_Encrypted_EN(keywordFiltered); }
            else if (language == Language.Czech) { charsEncrypted = Generate_Table_Encrypted_CZ(keywordFiltered); }
            else { charsEncrypted = Generate_Table_Encrypted_CZ_small(keywordFiltered); }

            textBox_keyword_filtered.Text = keywordFiltered;
            textBox_encrypted_table.Clear();

            int i_max, j_max;
            if (language == Language.English || language == Language.CzechSmall) { i_max = j_max = 5; }
            else
            {
                i_max = 5;
                j_max = 8;
            }
            
            for (int i = 0; i < i_max; i++) // Encrypted table output
            {
                for (int j = 0; j < j_max; j++)
                {
                    textBox_encrypted_table.Text += charsEncrypted[i, j];
                    textBox_encrypted_table.Text += ' ';
                }

                textBox_encrypted_table.Text += Environment.NewLine;
            }

            if (textBox_keyword.Text != "")
            {
                textBox_keyword.Enabled = false;
                button_keyword.Enabled = false;
                textBox_encrypted_table.Enabled = false;
                textBox_keyword_filtered.Enabled = false;
            
                button_keyword_change.Enabled = true;
                button_text_Encrypt.Enabled = true;
                button_text_Decrypt.Enabled = true;
            }
        }
        
        private void button_keyword_change_Click(object sender, EventArgs e)
        {
            textBox_keyword.Enabled = true;
            button_keyword.Enabled = true;
            textBox_encrypted_table.Enabled = true;
            textBox_keyword_filtered.Enabled = true;
            
            button_keyword_change.Enabled = false;
            button_text_Encrypt.Enabled = false;
            button_text_Decrypt.Enabled = false;
        }

        private void button_text_filter_Click(object sender, EventArgs e)
        {
            if (textBox_text_input.Text == "")
            {
                MessageBox.Show("Please enter a text to filter.");
                return;
            }
            
            if (language == Language.English) { textBox_text_output.Text = Filter_String_EN(textBox_text_input.Text); }
            else if (language == Language.Czech) { textBox_text_output.Text = Filter_String_CZ(textBox_text_input.Text); }
            else { textBox_text_output.Text = Filter_String_CZ_small(textBox_text_input.Text); }

        }
        
        private void button_text_Encrypt_Click(object sender, EventArgs e)
        {
            if (textBox_text_input.Text == "")
            {
                MessageBox.Show("Please enter a text to Encrypt.");
                return;
            }
            
            string openText = textBox_text_input.Text;
            string openTextFiltered;
            char[,] EncryptedTable;
            string EncryptedText = "";
            
            if (language == Language.English)
            {
                openTextFiltered = Filter_String_EN(openText);
                EncryptedTable = Generate_Table_Encrypted_EN(textBox_keyword_filtered.Text);
                EncryptedText = Encrypt_String_EN(openTextFiltered, EncryptedTable);
            }
            else if (language == Language.Czech)
            {
                openTextFiltered = Filter_String_CZ(openText);
                EncryptedTable = Generate_Table_Encrypted_CZ(textBox_keyword_filtered.Text);
                EncryptedText = Encrypt_String_CZ(openTextFiltered, EncryptedTable);
            }
            else
            {
                openTextFiltered = Filter_String_CZ_small(openText);
                EncryptedTable = Generate_Table_Encrypted_CZ_small(textBox_keyword_filtered.Text);
                EncryptedText = Encrypt_String_CZ_small(openTextFiltered, EncryptedTable);
            }
            string EncryptedTextDivided = "";
            int i = 1;
            foreach (char c in EncryptedText)
            {
                EncryptedTextDivided += c;
                if (i == 5) {
                    EncryptedTextDivided += ' ';
                    i = 0;
                }
                i++;
            }
            textBox_text_output.Text = EncryptedTextDivided;
        }
        
        private void button_text_Decrypt_Click(object sender, EventArgs e)
        {
            string EncryptedText = textBox_text_input.Text;
            EncryptedText = EncryptedText.Replace(" ", "");
            char[,] EncryptedTable;
            string DecryptedText;
            string openText;

            if (language == Language.English)
            {
                EncryptedTable = Generate_Table_Encrypted_EN(textBox_keyword_filtered.Text);
                DecryptedText = Decrypt_String_EN(EncryptedText, EncryptedTable);
            }
            else if (language == Language.Czech)
            {
                EncryptedTable = Generate_Table_Encrypted_CZ(textBox_keyword_filtered.Text);
                DecryptedText = Decrypt_String_CZ(EncryptedText, EncryptedTable);
            }
            else
            {
                EncryptedTable = Generate_Table_Encrypted_CZ_small(textBox_keyword_filtered.Text);
                DecryptedText = Decrypt_String_CZ_small(EncryptedText, EncryptedTable);
            }
            openText = Defilter_String(DecryptedText);
            
            textBox_text_output.Text = openText;
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void button_language_en_Click(object sender, EventArgs e)
        {
            label_language.Text = "Current language: English";
            language = Language.English;
            
            button_language_en.Enabled = false;
            button_language_cz.Enabled = true;
            button_language_cz_small.Enabled = true;
            
            textBox_keyword.Enabled = true;
            button_keyword.Enabled = true;
            textBox_encrypted_table.Enabled = true;
            textBox_keyword_filtered.Enabled = true;
            
            button_keyword_change.Enabled = false;
            button_text_Encrypt.Enabled = false;
            button_text_Decrypt.Enabled = false;
        }

        private void button_language_cz_Click(object sender, EventArgs e)
        {
            label_language.Text = "Current language: Czech";
            language = Language.Czech;
            
            button_language_en.Enabled = true;
            button_language_cz.Enabled = false;
            button_language_cz_small.Enabled = true;
            
            textBox_keyword.Enabled = true;
            button_keyword.Enabled = true;
            textBox_encrypted_table.Enabled = true;
            textBox_keyword_filtered.Enabled = true;
            
            button_keyword_change.Enabled = false;
            button_text_Encrypt.Enabled = false;
            button_text_Decrypt.Enabled = false;
        }
        
        private void button_language_cz_small_Click(object sender, EventArgs e)
        {
            label_language.Text = "Current language: Czech (small)";
            language = Language.CzechSmall;
            
            button_language_en.Enabled = true;
            button_language_cz.Enabled = true;
            button_language_cz_small.Enabled = false;
            
            textBox_keyword.Enabled = true;
            button_keyword.Enabled = true;
            textBox_encrypted_table.Enabled = true;
            textBox_keyword_filtered.Enabled = true;
            
            button_keyword_change.Enabled = false;
            button_text_Encrypt.Enabled = false;
            button_text_Decrypt.Enabled = false;
        }
        
        private void button_info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Choose you language. \n2. Enter your keyword." +
                            "\n3. Press \"Use keyword\" (Your keyword will be filtered according to chosen language.)" +
                            "\n4. Put you text into the left textBox." +
                            "\n\n\"Encrypt\" - Encrypt your text using Encrypted table." +
                            "\n\"Filter\" - filter your text to understand how program sees your open text." +
                            "\n\"Decrypt\" - Decrypt your text back using Encrypted table." +
                            "\n\nNotes:" +
                            "\n\tAll special symbols will be deleted." +
                            "\n\tAll numbers are filtered to XWORDX." +
                            "\n\tAll spaces are filtered to XMEZERAX.");
        }

        string Keyword_Filter_EN(string keyword)
        {
            string keywordNormalized = keyword.Normalize(NormalizationForm.FormD);
            string keywordUpper = keywordNormalized.ToUpper();
            string keywordUpperCharacters = "";
            foreach (char character in keywordUpper)
            {
                if (character >= 65 && character <= 90)
                {
                    if (character == 74)
                    {
                        keywordUpperCharacters += 'I';
                    }
                    else
                    {
                        keywordUpperCharacters += character;
                    }
                }
            }

            char[] chars = keywordUpperCharacters.ToCharArray();
            string keywordFiltered = "";
            foreach (char c in chars)
            {
                if (!keywordFiltered.Contains(c))
                {
                    keywordFiltered += c;
                }
            }

            return keywordFiltered;
        }
        
        string Keyword_Filter_CZ(string keyword)
        {
            string keywordUpper = keyword.ToUpper();
            string keywordUpperCharacters = "";
            foreach (char character in keywordUpper)
            {
                if (character == 'w' || character == 'W')
                {
                    keywordUpperCharacters += 'V';
                    continue;
                }
                
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (czechTable[i, j] == character)
                        {
                            keywordUpperCharacters += character;
                            goto BreakCycle;
                        }
                    }
                }
                BreakCycle: ;
            }
            
            char[] chars = keywordUpperCharacters.ToCharArray();
            string keywordFiltered = "";
            foreach (char c in chars)
            {
                if (!keywordFiltered.Contains(c))
                {
                    keywordFiltered += c;
                }
            }

            return keywordFiltered;
        }
        
        string Keyword_Filter_CZ_small(string keyword)
        {
            string keywordNormalized = keyword.Normalize(NormalizationForm.FormD);
            string keywordUpper = keywordNormalized.ToUpper();
            string keywordUpperCharacters = "";
            foreach (char character in keywordUpper)
            {
                if (character >= 65 && character <= 90)
                {
                    if (character == 87)
                    {
                        keywordUpperCharacters += 'V';
                    }
                    else
                    {
                        keywordUpperCharacters += character;
                    }
                }
            }

            char[] chars = keywordUpperCharacters.ToCharArray();
            string keywordFiltered = "";
            foreach (char c in chars)
            {
                if (!keywordFiltered.Contains(c))
                {
                    keywordFiltered += c;
                }
            }

            return keywordFiltered;
        }

        char[,] Generate_Table_Encrypted_EN(string keyword)
        {
            char[,] tableEncrypted = new char[5, 5];

            char[] keywordChars = keyword.ToCharArray();
            int x = 0;
            int y = 0;
            int temp = 1;
            if (keywordChars.Length > 0)
            {
                while (temp - 1 < keywordChars.Length)
                {
                    tableEncrypted[x, y] = keywordChars[temp - 1];
                    y++;
                    if (temp % 5 == 0)
                    {
                        y = 0;
                        x++;
                    }
                    temp++;
                }
            }

            char[,] tableOriginal = englishTable;
            string remainedLetters = "";
            foreach (char letter in tableOriginal)
            {
                if (!keywordChars.Contains(letter))
                {
                    remainedLetters += letter;
                }
            }
            
            int temp1 = 0;
            for (int i = x; i < 5; i++)
            {
                for (int j = y; j < 5; j++)
                {
                    tableEncrypted[i, j] = remainedLetters[temp1];
                    temp1++;
                }

                y = 0;
            }
            
            return tableEncrypted;
        }
        
        char[,] Generate_Table_Encrypted_CZ(string keyword)
        {
            char[,] tableEncrypted = new char[5, 8];

            char[] keywordChars = keyword.ToCharArray();
            int x = 0;
            int y = 0;
            int temp = 1;
            if (keywordChars.Length > 0)
            {
                while (temp - 1 < keywordChars.Length)
                {
                    tableEncrypted[x, y] = keywordChars[temp - 1];
                    y++;
                    if (temp % 8 == 0)
                    {
                        y = 0;
                        x++;
                    }
                    temp++;
                }
            }

            char[,] tableOriginal = czechTable;
            string remainedLetters = "";
            foreach (char letter in tableOriginal)
            {
                if (!keywordChars.Contains(letter))
                {
                    remainedLetters += letter;
                }
            }
            
            int temp1 = 0;
            for (int i = x; i < 5; i++)
            {
                for (int j = y; j < 8; j++)
                {
                    tableEncrypted[i, j] = remainedLetters[temp1];
                    temp1++;
                }

                y = 0;
            }
            
            return tableEncrypted;
        }
        
        char[,] Generate_Table_Encrypted_CZ_small(string keyword)
        {
            char[,] tableEncrypted = new char[5, 5];

            char[] keywordChars = keyword.ToCharArray();
            int x = 0;
            int y = 0;
            int temp = 1;
            if (keywordChars.Length > 0)
            {
                while (temp - 1 < keywordChars.Length)
                {
                    tableEncrypted[x, y] = keywordChars[temp - 1];
                    y++;
                    if (temp % 5 == 0)
                    {
                        y = 0;
                        x++;
                    }
                    temp++;
                }
            }

            char[,] tableOriginal = czechSmallTable;
            string remainedLetters = "";
            foreach (char letter in tableOriginal)
            {
                if (!keywordChars.Contains(letter))
                {
                    remainedLetters += letter;
                }
            }
            
            int temp1 = 0;
            for (int i = x; i < 5; i++)
            {
                for (int j = y; j < 5; j++)
                {
                    tableEncrypted[i, j] = remainedLetters[temp1];
                    temp1++;
                }

                y = 0;
            }
            
            return tableEncrypted;
        }

        string Filter_String_EN(string openText)
        {
            string normalizedText = openText.Normalize(NormalizationForm.FormD);

            string filteredText = "";

            foreach (char c in normalizedText)
            {
                if (c == 'j' || c == 'J')
                {
                    filteredText = filteredText + "I";
                }
                else if (Char.IsUpper(c))
                {
                    filteredText = filteredText + c;
                }
                else if (Char.IsLower(c))
                {
                    char new_c = (char)((int)c - 32);
                    filteredText = filteredText + new_c;
                }
                else if (c == ' ')
                {
                    filteredText = filteredText + "XMEZERAX";
                }
                else if (char.IsDigit(c))
                {
                    filteredText += numbers_en[(int)char.GetNumericValue(c)];
                }
            }
            
            string filteredTextFinal = "";
            int temp = 0;
            while (true)
            {
                if (temp + 1 == filteredText.Length)
                {
                    filteredTextFinal += filteredText[temp];
                    break;
                }
                if (filteredText[temp] == filteredText[temp + 1])
                {
                    filteredTextFinal += filteredText[temp];
                    if (filteredText[temp] == 'X') { filteredTextFinal += 'Q'; } else { filteredTextFinal += 'X'; }
                }
                else
                {
                    filteredTextFinal += filteredText[temp];
                }
                temp++;
            }
            
            if (filteredTextFinal.Length % 2 != 0)
            {
                if (filteredTextFinal[filteredTextFinal.Length - 1] == 'X') { filteredTextFinal += 'Q';}
                else filteredTextFinal += 'X';
            }

            return filteredTextFinal;
        }
        
        string Filter_String_CZ(string openText)
        {
            string filteredText = "";

            foreach (char c in openText)
            {
                if (c == 'w' || c == 'W')
                {
                    filteredText = filteredText + "V";
                }
                else if (Char.IsUpper(c))
                {
                    filteredText = filteredText + c;
                }
                else if (Char.IsLower(c))
                {
                    char new_c = char.ToUpper(c);
                    filteredText = filteredText + new_c;
                }
                else if (c == ' ')
                {
                    filteredText = filteredText + "XMEZERAX";
                }
                else if (char.IsDigit(c))
                {
                    filteredText += numbers_cz[(int)char.GetNumericValue(c)];
                }
            }
            
            string filteredTextFinal = "";
            int temp = 0;
            while (true)
            {
                if (temp + 1 == filteredText.Length)
                {
                    filteredTextFinal += filteredText[temp];
                    break;
                }
                if (filteredText[temp] == filteredText[temp + 1])
                {
                    filteredTextFinal += filteredText[temp];
                    if (filteredText[temp] == 'X') { filteredTextFinal += 'Q'; } else { filteredTextFinal += 'X'; }
                }
                else
                {
                    filteredTextFinal += filteredText[temp];
                }
                temp++;
            }
            
            if (filteredTextFinal.Length % 2 != 0)
            {
                if (filteredTextFinal[filteredTextFinal.Length - 1] == 'X') { filteredTextFinal += 'Q';}
                else filteredTextFinal += 'X';
            }

            return filteredTextFinal;
        }
        
        string Filter_String_CZ_small(string openText)
        {
            string normalizedText = openText.Normalize(NormalizationForm.FormD);

            string filteredText = "";

            foreach (char c in normalizedText)
            {
                if (c == 'w' || c == 'W')
                {
                    filteredText = filteredText + "V";
                }
                else if (Char.IsUpper(c))
                {
                    filteredText = filteredText + c;
                }
                else if (Char.IsLower(c))
                {
                    char new_c = (char)((int)c - 32);
                    filteredText = filteredText + new_c;
                }
                else if (c == ' ')
                {
                    filteredText = filteredText + "XMEZERAX";
                }
                else if (char.IsDigit(c))
                {
                    filteredText += numbers_cz[(int)char.GetNumericValue(c)];
                }
            }
            
            string filteredTextFinal = "";
            int temp = 0;
            while (true)
            {
                if (temp + 1 == filteredText.Length)
                {
                    filteredTextFinal += filteredText[temp];
                    break;
                }
                if (filteredText[temp] == filteredText[temp + 1])
                {
                    filteredTextFinal += filteredText[temp];
                    if (filteredText[temp] == 'X') { filteredTextFinal += 'Q'; } else { filteredTextFinal += 'X'; }
                }
                else
                {
                    filteredTextFinal += filteredText[temp];
                }
                temp++;
            }
            
            if (filteredTextFinal.Length % 2 != 0)
            {
                if (filteredTextFinal[filteredTextFinal.Length - 1] == 'X') { filteredTextFinal += 'Q';}
                else filteredTextFinal += 'X';
            }

            return filteredTextFinal;
        }
        
        string Defilter_String(string DecryptedText)
        {
            string defilteredTextNoQ = "";
            bool doubleLetter = false;
            
            for (int i = 0; i < DecryptedText.Length; i++) // Removing Qs
            {
                if (DecryptedText.Length - i <= 2)
                {
                    if (doubleLetter)
                    {
                        defilteredTextNoQ += DecryptedText[i];
                        break;
                    }
                    else
                    {
                        defilteredTextNoQ += DecryptedText[i];
                        defilteredTextNoQ += DecryptedText[i+1];
                        break;
                    }
                }
                
                if (DecryptedText[i] == 'X' && DecryptedText[i + 2] == 'X' && DecryptedText[i + 1] == 'Q')
                {
                    if (doubleLetter)
                    {
                        defilteredTextNoQ += DecryptedText[i];
                        i++;
                        doubleLetter = false;
                        continue;
                    }
                    else
                    {
                        defilteredTextNoQ += DecryptedText[i];
                        defilteredTextNoQ += DecryptedText[i+2];
                        i++;
                        doubleLetter = true;
                    }
                }
                else
                {
                    if (doubleLetter)
                    {
                        doubleLetter = false;
                    }
                    else
                    {
                        defilteredTextNoQ += DecryptedText[i];
                        doubleLetter = false;
                    }
                    
                }
            }
            
            string defilteredText = defilteredTextNoQ;
            if (language == Language.English)
            {
                for (int i = 0; i < 10; i++)
                {
                    defilteredText = defilteredText.Replace($"{numbers_en[i]}", $"{numbers_en.Keys.ElementAt(i)}");
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    defilteredText = defilteredText.Replace($"{numbers_cz[i]}", $"{numbers_cz.Keys.ElementAt(i)}");
                }
            }
            defilteredText = defilteredText.Replace("XMEZERAX", " ");
            
            string defilteredTextFinal = "";
            doubleLetter = false;
            
            for (int i = 0; i < defilteredText.Length; i++) // Removing Xs
            {
                if (defilteredText.Length - i <= 2)
                {
                    if (doubleLetter)
                    {
                        defilteredTextFinal += defilteredText[i];
                        break;
                    }
                    else
                    {
                        defilteredTextFinal += defilteredText[i];
                        defilteredTextFinal += defilteredText[i+1];
                        break;
                    }
                }
                else
                {
                    doubleLetter = false;
                }
                
                if (defilteredText[i] == defilteredText[i + 2] && defilteredText[i + 1] == 'X')
                {
                    defilteredTextFinal += defilteredText[i];
                    defilteredTextFinal += defilteredText[i+2];
                    i = i + 2;
                    doubleLetter = true;
                }
                else
                {
                    defilteredTextFinal += defilteredText[i];
                }
            }

            if (defilteredTextFinal[defilteredTextFinal.Length - 2] == 'X' &&
                defilteredTextFinal[defilteredTextFinal.Length - 1] == 'Q')
            {
                defilteredTextFinal = defilteredTextFinal.Remove(defilteredTextFinal.Length - 1);
            }
            else if (defilteredTextFinal.Length % 2 == 0 && defilteredTextFinal[defilteredTextFinal.Length - 1] == 'X')
            {
                defilteredTextFinal = defilteredTextFinal.Remove(defilteredTextFinal.Length - 1);
            }
            
            return defilteredTextFinal;
        }

        string Encrypt_String_EN(string openText, char[,] EncryptedTable)
        {
            string EncryptedText = "";
            int x_temp_1 = 0, y_temp_1 = 0, x_temp_2 = 0, y_temp_2 = 0;

            if (openText.Length == 1)
            {
                EncryptedText = EncryptedText + openText[0] + 'X';
                return EncryptedText;
            }

            for (int i = 0; i < openText.Length; i = i+2)
            {
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        if (openText[i] == EncryptedTable[x, y])
                        {
                            x_temp_1 = x;
                            y_temp_1 = y;
                            goto SkipLoop1;
                        }
                    }
                }
                SkipLoop1:
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        if (openText[i + 1] == EncryptedTable[x, y])
                        {
                            x_temp_2 = x;
                            y_temp_2 = y;
                            goto SkipLoop2;
                        }
                    }
                }
                SkipLoop2:
                
                if (x_temp_1 == x_temp_2)
                {
                    if (y_temp_1 == 4) { y_temp_1 = 0; } else y_temp_1++;
                    if (y_temp_2 == 4) { y_temp_2 = 0; } else y_temp_2++;
                    EncryptedText += EncryptedTable[x_temp_1, y_temp_1];
                    EncryptedText += EncryptedTable[x_temp_2, y_temp_2];
                }
                else if (y_temp_1 == y_temp_2)
                {
                    if (x_temp_1 == 4) { x_temp_1 = 0; } else x_temp_1++;
                    if (x_temp_2 == 4) { x_temp_2 = 0; } else x_temp_2++;
                    EncryptedText += EncryptedTable[x_temp_1, y_temp_1];
                    EncryptedText += EncryptedTable[x_temp_2, y_temp_2];
                }
                else
                {
                    EncryptedText += EncryptedTable[x_temp_1, y_temp_2];
                    EncryptedText += EncryptedTable[x_temp_2, y_temp_1];
                }
            }

            return EncryptedText;
        }
        
        string Encrypt_String_CZ(string openText, char[,] EncryptedTable)
        {
            string EncryptedText = "";
            int x_temp_1 = 0, y_temp_1 = 0, x_temp_2 = 0, y_temp_2 = 0;

            if (openText.Length == 1)
            {
                EncryptedText = EncryptedText + openText[0] + 'X';
                return EncryptedText;
            }

            for (int i = 0; i < openText.Length; i = i+2)
            {
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if (openText[i] == EncryptedTable[x, y])
                        {
                            x_temp_1 = x;
                            y_temp_1 = y;
                            goto SkipLoop1;
                        }
                    }
                }
                SkipLoop1:
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if (openText[i + 1] == EncryptedTable[x, y])
                        {
                            x_temp_2 = x;
                            y_temp_2 = y;
                            goto SkipLoop2;
                        }
                    }
                }
                SkipLoop2:
                
                if (x_temp_1 == x_temp_2)
                {
                    if (y_temp_1 == 7) { y_temp_1 = 0; } else y_temp_1++;
                    if (y_temp_2 == 7) { y_temp_2 = 0; } else y_temp_2++;
                    EncryptedText += EncryptedTable[x_temp_1, y_temp_1];
                    EncryptedText += EncryptedTable[x_temp_2, y_temp_2];
                }
                else if (y_temp_1 == y_temp_2)
                {
                    if (x_temp_1 == 4) { x_temp_1 = 0; } else x_temp_1++;
                    if (x_temp_2 == 4) { x_temp_2 = 0; } else x_temp_2++;
                    EncryptedText += EncryptedTable[x_temp_1, y_temp_1];
                    EncryptedText += EncryptedTable[x_temp_2, y_temp_2];
                }
                else
                {
                    EncryptedText += EncryptedTable[x_temp_1, y_temp_2];
                    EncryptedText += EncryptedTable[x_temp_2, y_temp_1];
                }
            }

            return EncryptedText;
        }
        
        string Encrypt_String_CZ_small(string openText, char[,] EncryptedTable)
        {
            string EncryptedText = "";
            int x_temp_1 = 0, y_temp_1 = 0, x_temp_2 = 0, y_temp_2 = 0;

            if (openText.Length == 1)
            {
                EncryptedText = EncryptedText + openText[0] + 'X';
                return EncryptedText;
            }

            for (int i = 0; i < openText.Length; i = i+2)
            {
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        if (openText[i] == EncryptedTable[x, y])
                        {
                            x_temp_1 = x;
                            y_temp_1 = y;
                            goto SkipLoop1;
                        }
                    }
                }
                SkipLoop1:
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        if (openText[i + 1] == EncryptedTable[x, y])
                        {
                            x_temp_2 = x;
                            y_temp_2 = y;
                            goto SkipLoop2;
                        }
                    }
                }
                SkipLoop2:
                
                if (x_temp_1 == x_temp_2)
                {
                    if (y_temp_1 == 4) { y_temp_1 = 0; } else y_temp_1++;
                    if (y_temp_2 == 4) { y_temp_2 = 0; } else y_temp_2++;
                    EncryptedText += EncryptedTable[x_temp_1, y_temp_1];
                    EncryptedText += EncryptedTable[x_temp_2, y_temp_2];
                }
                else if (y_temp_1 == y_temp_2)
                {
                    if (x_temp_1 == 4) { x_temp_1 = 0; } else x_temp_1++;
                    if (x_temp_2 == 4) { x_temp_2 = 0; } else x_temp_2++;
                    EncryptedText += EncryptedTable[x_temp_1, y_temp_1];
                    EncryptedText += EncryptedTable[x_temp_2, y_temp_2];
                }
                else
                {
                    EncryptedText += EncryptedTable[x_temp_1, y_temp_2];
                    EncryptedText += EncryptedTable[x_temp_2, y_temp_1];
                }
            }

            return EncryptedText;
        }

        string Decrypt_String_EN(string EncryptedText, char[,] EncryptedTable)
        {
            string DecryptedText = "";
            
            int x_temp_1 = 0, y_temp_1 = 0, x_temp_2 = 0, y_temp_2 = 0;

            if (EncryptedText.Length % 2 != 0)
            {
                MessageBox.Show("Encrypted text is wrong length!");
                return "NULL";
            }

            for (int i = 0; i < EncryptedText.Length; i = i+2)
            {
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        if (EncryptedText[i] == EncryptedTable[x, y])
                        {
                            x_temp_1 = x;
                            y_temp_1 = y;
                            goto SkipLoop1;
                        }
                    }
                }
                SkipLoop1:
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        if (EncryptedText[i + 1] == EncryptedTable[x, y])
                        {
                            x_temp_2 = x;
                            y_temp_2 = y;
                            goto SkipLoop2;
                        }
                    }
                }
                SkipLoop2:
                
                if (x_temp_1 == x_temp_2)
                {
                    if (y_temp_1 == 0) { y_temp_1 = 4; } else y_temp_1--;
                    if (y_temp_2 == 0) { y_temp_2 = 4; } else y_temp_2--;
                    DecryptedText += EncryptedTable[x_temp_1, y_temp_1];
                    DecryptedText += EncryptedTable[x_temp_2, y_temp_2];
                }
                else if (y_temp_1 == y_temp_2)
                {
                    if (x_temp_1 == 0) { x_temp_1 = 4; } else x_temp_1--;
                    if (x_temp_2 == 0) { x_temp_2 = 4; } else x_temp_2--;
                    DecryptedText += EncryptedTable[x_temp_1, y_temp_1];
                    DecryptedText += EncryptedTable[x_temp_2, y_temp_2];
                }
                else
                {
                    DecryptedText += EncryptedTable[x_temp_1, y_temp_2];
                    DecryptedText += EncryptedTable[x_temp_2, y_temp_1];
                }
            }

            return DecryptedText;
        }
        
        string Decrypt_String_CZ(string EncryptedText, char[,] EncryptedTable)
        {
            string DecryptedText = "";
            
            int x_temp_1 = 0, y_temp_1 = 0, x_temp_2 = 0, y_temp_2 = 0;

            if (EncryptedText.Length % 2 != 0)
            {
                MessageBox.Show("Encrypted text is wrong length!");
                return "NULL";
            }

            for (int i = 0; i < EncryptedText.Length; i = i+2)
            {
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if (EncryptedText[i] == EncryptedTable[x, y])
                        {
                            x_temp_1 = x;
                            y_temp_1 = y;
                            goto SkipLoop1;
                        }
                    }
                }
                SkipLoop1:
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if (EncryptedText[i + 1] == EncryptedTable[x, y])
                        {
                            x_temp_2 = x;
                            y_temp_2 = y;
                            goto SkipLoop2;
                        }
                    }
                }
                SkipLoop2:
                
                if (x_temp_1 == x_temp_2)
                {
                    if (y_temp_1 == 0) { y_temp_1 = 7; } else y_temp_1--;
                    if (y_temp_2 == 0) { y_temp_2 = 7; } else y_temp_2--;
                    DecryptedText += EncryptedTable[x_temp_1, y_temp_1];
                    DecryptedText += EncryptedTable[x_temp_2, y_temp_2];
                }
                else if (y_temp_1 == y_temp_2)
                {
                    if (x_temp_1 == 0) { x_temp_1 = 4; } else x_temp_1--;
                    if (x_temp_2 == 0) { x_temp_2 = 4; } else x_temp_2--;
                    DecryptedText += EncryptedTable[x_temp_1, y_temp_1];
                    DecryptedText += EncryptedTable[x_temp_2, y_temp_2];
                }
                else
                {
                    DecryptedText += EncryptedTable[x_temp_1, y_temp_2];
                    DecryptedText += EncryptedTable[x_temp_2, y_temp_1];
                }
            }

            return DecryptedText;
        }
        
        string Decrypt_String_CZ_small(string EncryptedText, char[,] EncryptedTable)
        {
            string DecryptedText = "";
            
            int x_temp_1 = 0, y_temp_1 = 0, x_temp_2 = 0, y_temp_2 = 0;

            if (EncryptedText.Length % 2 != 0)
            {
                MessageBox.Show("Encrypted text is wrong length!");
                return "NULL";
            }

            for (int i = 0; i < EncryptedText.Length; i = i+2)
            {
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        if (EncryptedText[i] == EncryptedTable[x, y])
                        {
                            x_temp_1 = x;
                            y_temp_1 = y;
                            goto SkipLoop1;
                        }
                    }
                }
                SkipLoop1:
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        if (EncryptedText[i + 1] == EncryptedTable[x, y])
                        {
                            x_temp_2 = x;
                            y_temp_2 = y;
                            goto SkipLoop2;
                        }
                    }
                }
                SkipLoop2:
                
                if (x_temp_1 == x_temp_2)
                {
                    if (y_temp_1 == 0) { y_temp_1 = 4; } else y_temp_1--;
                    if (y_temp_2 == 0) { y_temp_2 = 4; } else y_temp_2--;
                    DecryptedText += EncryptedTable[x_temp_1, y_temp_1];
                    DecryptedText += EncryptedTable[x_temp_2, y_temp_2];
                }
                else if (y_temp_1 == y_temp_2)
                {
                    if (x_temp_1 == 0) { x_temp_1 = 4; } else x_temp_1--;
                    if (x_temp_2 == 0) { x_temp_2 = 4; } else x_temp_2--;
                    DecryptedText += EncryptedTable[x_temp_1, y_temp_1];
                    DecryptedText += EncryptedTable[x_temp_2, y_temp_2];
                }
                else
                {
                    DecryptedText += EncryptedTable[x_temp_1, y_temp_2];
                    DecryptedText += EncryptedTable[x_temp_2, y_temp_1];
                }
            }

            return DecryptedText;
        }
    }
}