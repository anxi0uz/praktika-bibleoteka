   M S B A M L   `   `   `  ����I  Elibrary-client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:library_client.Windowslibrary_client.Windows  5   	   '    !library_client.Windows.UserWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:library_client.Windows     5   	     � Title$  Читатель         ��5   	   $	��450��5	      $	��800��6    � WindowStartupLocation$ CenterScreen=�6$   .��5
      � .+�5   
   �� -   5         ��Name$ mycard��5      $#��Личная карточка��6!   $
��Left=�6;   $��	10,10,0,0q�6V   $	��Top=�6i   $	��155��6�   6�   �� 5   
   -   5         ��Name$ BookNameTextBox��5      $
��Left=�6+   $��	10,49,0,0q�6F    �� TextWrapping$
 Wrap=�6Y   $	��Top=�6m   $	��205��6�   �� 5   
   -   5        $ SearchButton��5      $��
Поиск��6'   $
��Left=�67   $��
240,48,0,0q�6R   $	��Top=�6f   $	��105��6~   6�   �� 5   
   -   5         ��Name$ AuthorComboBox��5      $
��Left=�6+   $��
370,47,0,0q�6F   $	��Top=�6Z   $	��120��6r    �� DisplayMemberPath$	 fio��6~    �� SelectedValuePath$	 fio��6�   6�   �� 5   
   -   5        $ GenreComboBox��5      $
��Left=�6*   $��
515,47,0,0q�6E   $	��Top=�6Y   $	��120��6q   $
 name��6}   $
 name��6�   6�   �� 5   
   -   5        $ 
ExitButton��5      $��
Выход��6%   $
��Left=�65   $��	695,5,0,0q�6P   $	��Top=�6c   $��95��6{   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ booksDataGrid��5      $��10,74,10,10q�6U   	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$		 120 6j   �� 5   
   $��
Автор��6   $
��Left=�6    $��
370,21,0,0q�6;   $	��Top=�6O   �� 5   
   $��Жанр��6   $
��Left=�6   $��
515,21,0,0q�6:   $	��Top=�6N   �� 5   
   -   5        $ Update��5      $��Обновить��6!   $
��Left=�64   $��
670,49,0,0q�6O   $	��Top=�6c   $��90��6{   6�   5      5      