   M S B A M L   `   `   `  ����I  Elibrary-client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:library_client.Windowslibrary_client.Windows  5   	   -    'library_client.Windows.CreateUserWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:library_client.Windows     5   	     � Title$-  'Создать пользователя��5   	   $	��374��6&   $	��390��63    � WindowStartupLocation$ CenterScreen=�6?   .��5	      � .+�5
   
   �� -   5         ��Name$ LoginTextBox��5
      $
��Left=�6(   $��
150,76,0,0q�6C    �� TextWrapping$
 Wrap=�6W   $	��Top=�6k   $	��220��6�   �� 5   
   -   5        $ PasswordTextbox��5      $
��Left=�6+   $��150,117,0,0q�6F   $
 Wrap=�6[   $	��Top=�6o   $	��220��6�   �� 5   
   -   5        $ 
FioTextBox��5      $
��Left=�6&   $��150,153,0,0q�6A   $
 Wrap=�6V   $	��Top=�6j   $	��220��6�   �� 5   
   -   5        $ BirthTextBox��5      $
��Left=�6(   $��150,203,0,0q�6C   $
 Wrap=�6X   $	��Top=�6l   $	��220��6�   �� 5   
   -   5        $ AdressTextBox��5      $
��Left=�6)   $��150,251,0,0q�6D   $
 Wrap=�6Y   $	��Top=�6m   $	��220��6�   �� 5   
   -   5        $ PhoneTextBox��5      $
��Left=�6(   $��150,293,0,0q�6C   $
 Wrap=�6X   $	��Top=�6l   $	��220��6�   �� 5   
   -   5         ��Name$ CreateUserButton��5      $��Сохранить��6+   $
��Left=�6?   $��
10,316,0,0q�6Z   $	��Top=�6n   $	��360��6�   6�   �� 5   
   $��
Логин��6   $
��Left=�6    $��	10,72,0,0q�6;   $	��Top=�6N   �� 5   
   $��Пароль��6   $
��Left=�6!   $��
10,117,0,0q�6<   $	��Top=�6P   �� 5   
   $��ФИО��6   $
��Left=�6   $��
10,149,0,0q�69   $	��Top=�6M   �� 5   
   $��Дата Рождения��6   $
��Left=�6(   $��
10,199,0,0q�6C   $	��Top=�6W   $��43��6o   $	��115��6{   �� 5   
   $��
Адрес��6   $
��Left=�6    $��
10,247,0,0q�6;   $	��Top=�6O   �� 5   
   $��Телефон��6   $
��Left=�6"   $��
10,285,0,0q�6=   $	��Top=�6Q   �� 5   
   -   5        $ 	idTextBox��5      $
��Left=�6%   $��
150,32,0,0q�6@   $
 Wrap=�6T   $	��Top=�6h   $	��220��6�   $y�Hidden=�6�   �� 5   
   -	   5         ��Name$ idlabel��5      $��Id��6!   $
��Left=�6.   $��9,32,0,0q�6I   $	��Top=�6[   $y�Hidden=�6s   5      5      