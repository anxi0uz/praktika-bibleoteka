   M S B A M L   `   `   `  ����I  Elibrary-client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:library_client.Windowslibrary_client.Windows  5   	   &     library_client.Windows.AdminUser   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:library_client.Windows     5   	     � Title$7  1Управление пользователями��5   	   $	��450��6+   $	��800��68    � WindowStartupLocation$ CenterScreen=�6D   .��5	      � .+�5
   
   �� -   5         ��Name$ 
ExitButton��5
      $��
Выход��6%   $
��Left=�65   $��
706,10,0,0q�6P   $	��Top=�6d   $��84��6|   6�   �� 5   
   -   5        $ 
CreateUser��5      $��Создать��6%   $
��Left=�67   $��
10,388,0,0q�6R   $	��Top=�6f   $	��112��6~   6�   �� 5   
   -   5        $ UpdateUserButton��5      $��Обновить��6+   $
��Left=�6>   $��142,387,0,0q�6Y   $	��Top=�6n   $	��112��6�   6�   �� 5   
   -   5        $ DeleteUserButton��5      $��Удалить��6+   $
��Left=�6=   $��288,386,0,0q�6X   $	��Top=�6m   $	��112��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ UsersDataGrid��5      $��10,49,10,69q�6U   �� 5   
   -   5         ��Name$ idTextBoxForDelete��5      $
��Left=�6.   $��528,387,0,0q�6I    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��120��6�   �� 5   
   $ ��ID для удаления��6   $
��Left=�6*   $��425,382,0,0q�6E   $	��Top=�6Z   �� 5   
   -   5        $ UpdateDataGrid��5      $'��!Обеновить таблицу��6)   $
��Left=�6E   $��672,385,0,0q�6`   $	��Top=�6u   6�   5      5      