<script type="text/javascript"> 
var script_costCSDataWOnGLGroup = {
    ACEProjectGroupID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ProjectGroupID','');
      var F_ProjectGroupID = $get(sender._element.id);
      var F_ProjectGroupID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ProjectGroupID.value = p[0];
      F_ProjectGroupID_Display.innerHTML = e.get_text();
    },
    ACEProjectGroupID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ProjectGroupID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEProjectGroupID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEFinYear_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('FinYear','');
      var F_FinYear = $get(sender._element.id);
      var F_FinYear_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_FinYear.value = p[0];
      F_FinYear_Display.innerHTML = e.get_text();
    },
    ACEFinYear_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('FinYear','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEFinYear_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEQuarter_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('Quarter','');
      var F_Quarter = $get(sender._element.id);
      var F_Quarter_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_Quarter.value = p[0];
      F_Quarter_Display.innerHTML = e.get_text();
    },
    ACEQuarter_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('Quarter','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEQuarter_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEGLGroupID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('GLGroupID','');
      var F_GLGroupID = $get(sender._element.id);
      var F_GLGroupID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_GLGroupID.value = p[0];
      F_GLGroupID_Display.innerHTML = e.get_text();
    },
    ACEGLGroupID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('GLGroupID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEGLGroupID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    temp: function() {
    }
    }
</script>
