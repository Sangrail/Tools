   M S B A M L   `   `   `  ����O  KDeepSearchStandAlone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:DeepSearchStandAloneDeepSearchStandAlone  5   	   %    DeepSearchStandAlone.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4local"clr-namespace:DeepSearchStandAlone     5   	   -   5          � Title$  
MainWindow��5   	   $��471.4��6   $	��525��6+    � 	Resources 5      (   "DeepSearchStandAlone.SearchResults   searchResults  tableViewSource �� Source �� Source��%V   &	        &	      7     5   
   6   �� 5   
    67   �� *Table+8   5	      .��5
      �  � DataContext# [ 6    � RowDefinitions 5   
   �� 5      $
��220* �6   �� 5      $��8* �6   �� 5      $	��29* �6   �� 5      $
��183* �6   .+�5   
   �� -   5         ��Name$ 	queryText��5      $��60��6%   $��
10,10,10,0q�61    �� TextWrapping$
 Wrap=�6E   $����SELECT System.ItemName, System.ItemUrl, System.FileExtension, System.FileName, System.FileAttributes, System.FileOwner, System.ItemType, System.ItemTypeText , System.KindText, System.Kind, System.MIMEType, System.Size FROM SYSTEMINDEX  WHERE System.ItemType = '.pdf'��6Y   $	��Top=�6k  �� 5   
   -   5         ��Name$ Search��5      $��Search��6!   $��
10,70,10,0q�62   $	��Top=�6F   $��51��6^   6j   &   System.Windows.Controls.DataGrid  5   
   -   5        	  Name$	 gridResults��5      $��10,126,10,10q�6(   $��4��6>   
   
IsReadOnly
 . ��6a   ��  �� Path$ .�5      5      5      