   M S B A M L   `   `   `  ����H  DTaskDocWriter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TaskDocWriter.ViewsTaskDocWriter.Views  5   	   ;"clr-namespace:TaskDocWriter.ModelsTaskDocWriter.Models  5   	   %    TaskDocWriter.Views.InputPrompt   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:TaskDocWriter.Views     5   	   1VM"clr-namespace:TaskDocWriter.Models     5   	     � Title$  InputPrompt��5	   	   $	��125��6   $	��600��6*    � 
ResizeMode$ NoResize=�66    � DataContext 5
      $   TaskDocWriter.Models.UserModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��25 �6   6*   �� 5      $��50 �6   6*    � ColumnDefinitions 5   
   �� 5      $	��150 �6   6-   �� 5      $	��150 �6   6-   �� 5      $	��150 �6   6-   �� 5      $	��150 �6   6-   .+�5   
   �� $��Center=�6   $��Center=�64   $��0��6Q   $��25��6^   $��75��6j   .��6u   Фамилия6~   �� 5   
   $��Center=�6   $��0��64   $��1��6A   $��25��6Q   $��75��6]   .��6i   Телефон6r   �� 5   
   $��Center=�6   $��2��64   $��25��6D   $��75��6P   .��6[   Email6b   �� 5   
   -   5         ��Name$ 
surnameBox��5      $��1��6&   $��0��63   $��20��6C   $��75��6O   6\   �� 5   
   -   5        $ phoneBox��5      $��1��6$   $��1��61   $��20��6A   $��75��6M   6Z   �� 5   
   -   5        $ emailBox��5      $��1��6$   $��2��61   $��20��6A   $��75��6M   6Z   �� 5   
   -   5        $��1��5      $��3��6   $��25��6.   $��75��6:   .��6d   Готово6l   5      5       