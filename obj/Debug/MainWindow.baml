   M S B A M L   `   `   `  ����K  GTicketing System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Ticketing_SystemTicketing_System  5   	   !    Ticketing_System.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Ticketing_System     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5	   	    � Title$ Log-In Page��5
   	   $	��615��6   $	��800��6*   .��5      � $��0,0,0,-6q�6   .+�5   
   �� $
��Left=�6   $	��286��6/   $��130,176,0,0q�6<   
���   �$	��Top=�6`   $	��556��6x   �� 5   
   -   5         ��Name$ uname��5      $
��Left=�6!   $��324,202,0,0q�6<    �� TextWrapping$
 Wrap=�6Q   $	��Top=�6e   $	��266��6}   $��24(�6�   6�   G� 5   
   -   5         G�Name$ passw��5      $
��Left=�6%   $��325,288,0,0q�6@   $	��Top=�6U   $	��265��6m   $��30��6y   $��14(�6�   �� 5   
   $��
Username :��6   $
��Left=�6%   $��182,198,0,0q�6@   $	��Top=�6U   $��42��6m   $	��147��6y   $��24(�6�   $
��Bold"�6�   �� 5   
   $��
Password :��6   $
��Left=�6%   $��182,275,0,0q�6@   $	��Top=�6U   $��43��6m   $	��152��6y   $��24(�6�   $
��Bold"�6�   �� 5   
   $
��Left=�6   $	��161��6+   $��
328,10,0,0q�68   $	��Top=�6L   $	��168��6d   $��Resources/logo.png��6p   �� 5   
   -   5         ��Name$ loginbutton��5      $��Login��6&   $
��Left=�66   $��220,407,0,0q�6Q   $	��Top=�6f   $��24(�6�   $��40��6�   $	��139��6�   �� 5   
   -   5        $ clearbutton��5      $��Clear��6&   $
��Left=�66   $��457,407,0,0q�6Q   $	��Top=�6f   $��24(�6�   $��41��6�   $	��139��6�   �� 5   
   $��Dont have an Account?��6   $��Center=�60   $��	0,487,0,0q�6M   $	��Top=�6`   $��18(�6x   �� 5   
   -   5         ��Name$ nopass��5      $�� ��6    $
��Left=�6+   $��324,323,0,0q�6F   $	��Top=�6[   $��14(�6s   $	��266��6�   �� 5   
   -   5        $ nouname��5      $�� ��6!   $
��Left=�6,   $��325,241,0,0q�6G   $	��Top=�6\   $��14(�6t   $	��265��6�   �� 5   
   -   5        $ Register��5      $��Create An Account��6#   $��Center=�6?   $��	0,521,0,0q�6\   $	��Top=�6o   $��18(�6�   
�������$��0q�6�   6�   5      5      