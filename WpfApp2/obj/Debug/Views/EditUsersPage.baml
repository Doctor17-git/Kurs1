   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp2.ViewsWpfApp2.Views  5   	   !    WpfApp2.Views.EditUsersPage   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WpfApp2.Views     5   	     � Title$=  7Редактирование пользователей��5   	   $	��450��6.   $	��800��6;   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $-��'Список пользователей��6   $��16(�64   $
��Bold"�6B   $��0,5,0,5q�6T   �� 5      -   5         ��Name$ UsersListView��5      $��1��6.   $
��0,10q�6;    �� View 5      �� 5      .P�5      �� $��
Логин��6)    �� Width$	 200��6b    �� DisplayMemberBinding 68   �� *
Username+6b   �� 5      $��Роль��6)   $	 150��6]    67   �� *Role+6]   �� 5      $��Действия��6)   $	 200��6;    �� CellTemplate 5      �� 5   "   .R�5   &   �� $ 
Horizontal=�61   .+�5   *   �� -   5        $��Удалить��5   1   $��5q�6C   ��6N   �� 6k   5   '   5   #   5      5       5"      �� 5#      $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5$      �� -   5        $/��)Добавить пользователя��5$      $	��150��69   6E   �� 5%      -   5        $5��/Редактировать выбранного��5%      $	��200��6<   $��10,0,0,0q�6H   6Z   5&      5'      5(      5)      