   M S B A M L   `   `   `  ����|  xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�rclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit)System.Windows.Controls.DataVisualization  5   	   �{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5   	    esem_homework_sma_by_ks8   2esem_homework_sma_by_ks.MetricsVisualizationWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   �DVrclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	   �DVC{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	   -   5          � Title$   MetricsVisualizationWindow��5   	   $��422.804��6,   $��974.688��6=   .��5      � $��10,0,0,0q�6   .+�5   
   >   8System.Windows.Controls.DataVisualization.Charting.Chart  -   5        $��MetricChart��5      
 �� Top$ 80��6'    �� Left$ 10��67   $	��285��6I   
�������$��	10,10,0,0q�6l   $
��Left=�6   $	��Top=�6�   $	��722��6�      Series 5
      E   ?System.Windows.Controls.DataVisualization.Charting.ColumnSeries  ?   9System.Windows.Controls.DataVisualization.Charting.Series   Title$ Metric��6#   H   BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   IndependentValueBinding 62   ��  �� Path$	 Key�   DependentValueBinding 6_   �� $ Value�   DataPointStyle 5      �� 5      	 �� 
TargetTypeH   BSystem.Windows.Controls.DataVisualization.Charting.ColumnDataPoint"	  6    .�5      �� 
 �� Property
 � �� �� Value
 �k���6;   5      5         Axes 5      C   =System.Windows.Controls.DataVisualization.Charting.LinearAxis  -   5          Name$ YLinearAxis��5   !   =   7System.Windows.Controls.DataVisualization.Charting.Axis   Orientation$ Y=�66   D   >System.Windows.Controls.DataVisualization.Charting.DisplayAxis   Title$ Percentages��6F   
���   �
�������$��TimesNewRoman)�6�   $��14(�6�   $
��Bold"�6�      Interval�	   �System.Windows.Controls.DataVisualization.Charting.NullableConverter`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]$ 10	 6�     5      -   5        $ XLinearAxis��5   !   $ X=�66   $ 	Intervals��6F   
���   �
�������$��TimesNewRoman)�6~   $��14(�6�   $
��Bold"�6�   5      �� 5   
   -   5         ��Name$ MetricListBox��5      $
��Left=�6)   $	��167��6D   $��
750,10,0,0q�6Q   $	��Top=�6e   $	��100��6}   6�   �� 5   
   $��Sample mean:��6   $
��Left=�6'   $��750,194,0,0q�6B   $	��Top=�6W   $	��114��6o   �� 5   
   -   5         ��Name$ StandardDeviationLabel��5      $�� ��60   $
��Left=�6;   $��869,256,0,0q�6V   $	��Top=�6k   �� 5   
   $��	Variance:��6   $
��Left=�6$   $��750,225,0,0q�6?   $	��Top=�6T   $	��114��6l   �� 5   
   $��Standard Deviation:��6   $
��Left=�6.   $��750,256,0,0q�6I   $	��Top=�6^   �� 5   
   $��	Kurtosis:��6   $
��Left=�6$   $��750,287,0,0q�6?   $	��Top=�6T   $	��114��6l   �� 5   
   $��	Skewness:��6   $
��Left=�6$   $��750,318,0,0q�6?   $	��Top=�6T   $	��114��6l   �� 5   
   -   5        $ VarianceLabel��5      $�� ��6'   $
��Left=�62   $��869,225,0,0q�6M   $	��Top=�6b   �� 5   
   -   5        $ SampleMeanLabel��5      $�� ��6)   $
��Left=�64   $��869,194,0,0q�6O   $	��Top=�6d   �� 5    
   -	   5        $ KurtosisLabel��5       $�� ��6'   $
��Left=�62   $��869,287,0,0q�6M   $	��Top=�6b   �� 5!   
   -
   5        $ SkewnessLabel��5!      $�� ��6'   $
��Left=�62   $��869,318,0,0q�6M   $	��Top=�6b   �� 5"   
   -   5         ��Name$  NormalDistributionCheckBox��5"      $��Normal Distribution��67   $
��Left=�6U   $��
54,320,0,0q�6p   $	��Top=�6�   6�   �� 5#   
   -   5         ��Name$ 
NextButton��5#      $
��Next��6%   $
��Left=�64   $��
54,362,0,0q�6O   $	��Top=�6c   $��75��6{   6�   5$      5%      