   M S B A M L   `   `   `  ����I  Elibrary-client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:library_client.Windowslibrary_client.Windows  5   	   (    "library_client.Windows.WorkerBooks   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:library_client.Windows     5   	     � Title$)  #Управления книгами��5   	   $	��450��6$   $	��800��61    � WindowStartupLocation$ CenterScreen=�6=   .��5	      � .+�5
   
   �� -   5         ��Name$ GenreComboBox��5
      $
��Left=�6*   $��	10,62,0,0q�6E   $	��Top=�6X   $	��120��6p    �� DisplayMemberPath$
 name��6|    �� SelectedValuePath$
 name��6�   6�   �� 5   
   -   5        $ AuthorsComboBox��5      $
��Left=�6,   $��
280,62,0,0q�6G   $	��Top=�6[   $	��120��6s   $	 fio��6   $	 fio��6�   6�   �� 5   
   -   5        $ YearsComboBox��5      $
��Left=�6*   $��
565,62,0,0q�6E   $	��Top=�6Y   $	��120��6q   6}   �� 5   
   -   5         ��Name$ cancelButton��5      $��
Назад��6'   $
��Left=�67   $��
715,10,0,0q�6R   $	��Top=�6f   $��75��6~   6�   �� 5   
   -   5         ��Name$ searchingTextBox��5      $
��Left=�6,   $��
10,106,0,0q�6G    �� TextWrapping$
 Wrap=�6[   $	��Top=�6o   $	��270��6�   �� 5   
   -   5        $ SearchButton��5      $��
Поиск��6'   $
��Left=�67   $��302,104,0,0q�6R   $	��Top=�6g   6   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ BooksDataGrid��5      $��10,134,10,10q�6U   	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$		 125 6k   �� 5   
   -   5        $ AddBook��5      $!��Добавить книгу��6"   $
��Left=�6;   $��400,104,0,0q�6V   $	��Top=�6k   6�   �� 5   
   $��Жанр��6   $
��Left=�6   $��	10,31,0,0q�6:   $	��Top=�6M   �� 5   
   $��
Автор��6   $
��Left=�6    $��
280,26,0,0q�6;   $	��Top=�6O   �� 5   
   $��Год Издания��6   $
��Left=�6&   $��
565,34,0,0q�6A   $	��Top=�6U   �� 5   
   -	   5        $ UpdateButton��5      $��Обновить��6'   $
��Left=�6:   $��520,104,0,0q�6U   $	��Top=�6j   $��85��6�   6�   5      5      