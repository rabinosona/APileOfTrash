   M S B A M L   `   `   `  ����H  DTaskDocWriter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TaskDocWriter.ViewsTaskDocWriter.Views  5      ;"clr-namespace:TaskDocWriter.ModelsTaskDocWriter.Models  5      #    TaskDocWriter.Views.TitlePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:TaskDocWriter.Views     5      1VM"clr-namespace:TaskDocWriter.Models     5        N� Title$  	TitlePage��5
      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��75 �6   �� 5      $	��600 �6   �� 5      $��50 �6   �� 5      $	��200 �6   .+�5   
   �� -   5         ��Name$ UserDataList��5      $��1��6)   $��Stretch=�66   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property �@��
IsSelected �� Value 63   �� *
IsGroovy+6P   5       �� View 5      �� 5      .P�5      �� $��Фамилия��6%    �� Width$	 640��66    �� DisplayMemberBinding 6B   �� *	Surname+�� 5      $��Телефон��6%   $	 640��66    6B   �� *Phone+6k   �� 5      $��Email��6%   $	 640��64    6@   �� *Email+6i   5      5!      �� 5#   
   $��2��6   	 �� Orientation$	 
Horizontal=�6"   $��Center=�6;   .+�5$      �� -   5        
���   �$	��250��5$   (   .��6Q   Добавить6[   �� 5%      -   5        
���   �$	��250��5%   (   $��50, 0, 0, 0q�64   .��6i   Удалить6r   5&      �� 5'   
   $��4��6   $	 
Horizontal=�6"   $��Center=�6;   $��Center=�6V   .+�5(      �� -   5        $	��150��5(      .��6=   Искать6E   �� 5)      -   5        
 ��Name$
 UserSearchableSurname��5)      $	��100��65   $��30, 0, 0, 0q�6A   6X   �� 5*      -   5        $
 UserSearchablePhone��5*      $	��150��63   $��30, 0, 0, 0q�6?   6V   �� 5+      -   5        $
 UserSearchableEmail��5+      $	��150��64   $��30, 0, 0, 0q�6@   6W   5,      5-      5.      