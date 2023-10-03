<?php
/*
 * HINDLEWARE
 * Copyright (C) 2022 Eric Hindle. All rights reserved.
 */
$currentlevel = 000;
$adminlevelneeded = 999;
$devlevelneeded = 901;
?>

<header>
	<link rel="stylesheet" href="/hindleware/css/nav.css">
	<a href="<?php echo $myPath; ?>menus/home.php"> <img
		src="<?php echo $myPath; ?>img/CelebBirthdayLogo.png" alt="logo"
		class="logo-image" width="250" />
	</a>
	
	 	<?php echo '<h3>'.$_SESSION['book_name'].'</h3>';?>
	
	<div class="account" style="z-index: 99;" onClick="menuToggle();">
		<span class="account-icon" style="background-image: url(<?php echo $myPath; ?>img/icons/user.png)"></span>
		<div class="account-name"> 
		   	<?php echo $_SESSION['username'];?>
		</div>
		<div class="account-menu">
			<ul>
				<li>
					<form class="txt-btn" role="form" name="myaccount" method="post"
						action="<?php echo $myPath; ?>struct/player/myaccount.php">
					<?php echo $key; ?>
					<input id="submit" type="submit" value="Manage Your Account">
					</form>
				</li>
				<?php

if ($currentlevel == $adminlevelneeded || $currentlevel == $devlevelneeded) {
        echo '<li><a class="admin-btn" href="' . $myPath . 'struct/main.php">Admin</a></li>';
    }
    if ($currentlevel == $devlevelneeded) {
        echo '<li><a class="admin-btn" href="' . $myPath . 'menus\testmenu.php">Testing</a></li>';
    }
    ?>
				
				<li><a class="btn" href="<?php echo $myPath; ?>logout.php">Sign out</a></li>

			</ul>
		</div>
	</div>
</header>



<nav>
	<a
		class="nav-item <?php echo $currentPage == 'home' ? 'active' : ''; ?>"
		href="<?php echo $myPath; ?>menus/home.php"><span class="nav-icon" style="background-image: url(<?php echo $myPath; ?>img/icons/home-grey.png)"></span>Home</a>
	<a
		class="nav-item <?php echo $currentPage == 'people' ? 'active' : ''; ?>"
		href="<?php echo $myPath; ?>person/personsearch.php"><span class="nav-icon" style="background-image: url(<?php echo $myPath; ?>img/icons/people-grey.png)"></span>People</a>
	<a
		class="nav-item <?php echo $currentPage == 'deaths' ? 'active' : ''; ?>"
		href="<?php echo $myPath; ?>deaths/deathselectdates.php"><span class="nav-icon" style="background-image: url(<?php echo $myPath; ?>img/icons/place-grey.png)"></span>Deaths</a>
</nav>

<script>
	function menuToggle(){
		const toggleMenu = document.querySelector('.account');
		toggleMenu.classList.toggle('active')
	}
</script>

