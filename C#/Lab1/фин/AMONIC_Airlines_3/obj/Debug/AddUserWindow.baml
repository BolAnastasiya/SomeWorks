   M S B A M L   `   `   `  ����L  HAMONIC_Airlines_3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:AMONIC_Airlines_3AMONIC_Airlines_3  5   	   %    AMONIC_Airlines_3.AddUserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:AMONIC_Airlines_3     5   	   -   5          �Name$  AddUserWind��5   	    � Title$ AddUserWindow��5   	   $	��450��6   $	��500��6,   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $
��1.2* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��Center=�6X   .+�5      �� $��Email��6   $	��110��6$   $��30��60   $��Center=�6<   $��18(�6^   $��0q�6l   $��0,0,20,0q�6x   �� 5      -   5         ��Name$ tb_Email��5      $	��250��6(   $��30��64   $��18(�6@   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��Center=�6;   $��Center=�6X   .+�5      �� -   5         ��Name$ 	Firstname��5      $��	Firstname��6'   $	��110��6;   $��30��6G   $��Center=�6S   $��18(�6u   $��0q�6�   $��0,0,20,0q�6�   �� 5      -   5        $ tb_Name��5      $	��250��6'   $��30��63   $��18(�6?   5      �� 5   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   $��Center=�6X   .+�5      �� $��Lastname��6   $	��110��6'   $��30��63   $��Center=�6?   $��18(�6a   $��0q�6o   $��0,0,20,0q�6{   �� 5      -   5        $ 
tb_Surname��5      $	��250��6*   $��30��66   $��18(�6B   5      �� 5   
   $��3��6   $ 
Horizontal=�6"   $��Center=�6;   $��Center=�6X   .+�5       �� $��Office��6   $	��130��6%   $��30��61   $��Center=�6=   $��18(�6_   $��0q�6m   �� 5!      -   5         ��Name$ 	cb_Office��5!      $	��250��6*   $��30��66   $��18(�6B    �� SelectedIndex$ 0��6P   5"      �� 5#   
   $��4��6   $ 
Horizontal=�6"   $��Center=�6;   $��Center=�6X   .+�5$      �� $��	BirthDate��6   $	��127��6(   $��30��64   $��Center=�6@   $��18(�6b   $��0q�6p   �� 5%      -   5        $ tb_Birthdate��5%      $	��250��6,   $��30��68   $��18(�6D   5&      �� 5'   
   $��5��6   $ 
Horizontal=�6"   $��Center=�6;   $��Center=�6X   .+�5(      �� $��Password��6   $	��110��6'   $��30��63   $��Center=�6?   $��18(�6a   $��0q�6o   $��0,0,20,0q�6{   G� 5)      -   5         G�Name$ pb_password��5)      $	��250��6/   $��30��6;   $��18(�6G   5*      �� 5+   
   $��6��6   $ 
Horizontal=�6"   $��Center=�6;   $��Center=�6X   .+�5,      �� -	   5        	 ��Name$	 bt_save��5,      $
��Save��6&   $	��140��65   $��30��6A   $��15(�6M   $��0,0,40,0q�6[   6m   �� 5-      -
   5        $	 	bt_cancel��5-      $��Cancel��6(   $	��140��69   $��30��6E   $��15(�6Q   $��40,0,0,0q�6_   6q   5.      5/      50      