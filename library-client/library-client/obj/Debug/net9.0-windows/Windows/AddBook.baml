   M S B A M L   `   `   `  ����I  Elibrary-client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:library_client.Windowslibrary_client.Windows  5   	   $    library_client.Windows.AddBook   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:library_client.Windows     5   	     � Title$%  Добавление книги��5   	   $	��371��6"   $	��339��6/    � WindowStartupLocation$ CenterScreen=�6;   .��5	      � .+�5
   
   �� -   5         ��Name$ TitleTextBox��5
      $
��Left=�6(    �� TextWrapping$
 Wrap=�6C   $	��Top=�6W   $	��176��6o   $��30��6{   $��	96,10,0,0q�6�   �� 5   
   -   5        $ YearTextBox��5      $
��Left=�6'   $
 Wrap=�6B   $	��Top=�6V   $	��176��6n   $��30��6z   $��	96,99,0,0q�6�   �� 5   
   -   5        $ PriceTextBox��5      $
��Left=�6(   $
 Wrap=�6C   $	��Top=�6W   $	��176��6o   $��30��6{   $��
96,146,0,0q�6�   �� 5   
   -   5         ��Name$ 
CreateBook��5      $!��Добавить книгу��6%   $��Center=�6>   $��	0,254,0,0q�6[   $	��Top=�6n   $	��262��6�   6�   �� 5   
   -   5         ��Name$ authorsComboBox��5      $
��Left=�6,   $��	96,45,0,0q�6G   $	��Top=�6Z   $	��176��6r   $��49��6~    �� SelectedValuePath$ id��6�    �� DisplayMemberPath$	 fio��6�   �� 5   
   -   5        $ GenreComboBox��5      $
��Left=�6*   $��
96,181,0,0q�6E   $	��Top=�6Y   $	��176��6q   $��68��6}   $ id��6�   $
 name��6�   �� 5   
   $��Название��6   $
��Left=�6#   $��	10,14,0,0q�6>   $	��Top=�6Q   �� 5   
   $��
Автор��6   $
��Left=�6    $��	10,52,0,0q�6;   $	��Top=�6N   �� 5   
   $��Год издания��6   $
��Left=�6&   $��	10,96,0,0q�6A   $	��Top=�6T   �� 5   
   $��Цена��6   $
��Left=�6   $��
10,148,0,0q�6:   $	��Top=�6N   �� 5   
   $��Жанр��6   $
��Left=�6   $��
10,181,0,0q�6:   $	��Top=�6N   5      5      