   M S B A M L   `   `   `  ����I  Elibrary-client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:library_client.Windowslibrary_client.Windows  5   	   (    "library_client.Windows.WorkerUsers   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:library_client.Windows     5   	     � Title$/  )Управление читателями��5   	   $	��450��6'   $	��800��64    � WindowStartupLocation$ CenterScreen=�6@   .��5	      � .+�5
   
   �� -   5         ��Name$ FioComboBox��5
      $
��Left=�6(   $��	10,67,0,0q�6C   $	��Top=�6V   $	��120��6n    �� DisplayMemberPath$	 fio��6z    �� SelectedValuePath$	 fio��6�   6�   �� 5   
   -   5        $ BirthComboBox��5      $��Center=�6*   $��0,67,0,0q�6G   $	��Top=�6Y   $	��120��6q   $ 	birthDate��6}   $ 	birthDate��6�   6�   �� 5   
   -   5         ��Name$ 
ExitButton��5      $��
Назад��6%   $
��Left=�65   $��
695,10,0,0q�6P   $	��Top=�6d   $��95��6|   6�   �� 5   
   -   5         ��Name$ TicketNumberComboBox��5      $
��Left=�60   $��
10,109,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��310��6�   �� 5   
   -   5        $ SearchButton��5      $��
Поиск��6'   $
��Left=�67   $��360,108,0,0q�6R   $	��Top=�6g   $	��100��6   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ usersDataGrid��5      $��10,133,10,10q�6U   �� 5   
   -   5        	 ��Name$	 FioLabel��5      $��ФИО��6"   $
��Left=�60   $��	10,41,0,0q�6K   $	��Top=�6^   �� 5   
   $��Дата Рождения��6   $
��Left=�6(   $��
340,41,0,0q�6C   $	��Top=�6W   �� 5   
   -   5        $ updateButton��5      $��Обновить��6'   $
��Left=�6:   $��495,109,0,0q�6U   $	��Top=�6j   6�   �� 5   
   -	   5        $ CreateUserButton��5      $'��!Добавить читателя��6+   $
��Left=�6G   $��587,109,0,0q�6b   $	��Top=�6w   6�   5      5      