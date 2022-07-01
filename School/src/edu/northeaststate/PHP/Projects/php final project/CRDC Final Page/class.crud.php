<?php

class crud
{
	private $db;
	
	function __construct($DB_con)
	{
		$this->db = $DB_con;
	}

    public function create($userid,$classid)
    {
        try
        {
            $stmt = $this->db->prepare('INSERT INTO Permit_Requests(submission_date,completion_status,approval_status, user_id, class_id) VALUES(CURDATE(), 0, "Pending", :userid, :classid)');
        
            $stmt->bindparam(":userid",$userid);
            $stmt->bindparam(":classid",$classid);
            $stmt->execute();
            return true;
        }
        catch(PDOException $e)
        {
            echo $e->getMessage();
            return false;
        }

    }

    public function getID($id)
    {
        $stmt = $this->db->prepare("SELECT * FROM Permit_Requests WHERE user_id=:id");
        $stmt->execute(array(":id"=>$id));
        $editRow=$stmt->fetch(PDO::FETCH_ASSOC);
        return $editRow;
    }

    public function getUsername($username)
    {
        $stmt = $this->db->prepare("SELECT * FROM Users WHERE username=:username");
        $stmt->execute(array(":username" => $username));
        $editRow = $stmt->fetch(PDO::FETCH_ASSOC);
        return $editRow;
    }

	public function update($id,$approval)
	{
		try
		{
			$stmt=$this->db->prepare("UPDATE Permit_Requests SET completion_status=1, 
		                                               approval_status=:approval 
													WHERE request_id=:id ");
			$stmt->bindparam(":approval",$approval);
			$stmt->bindparam(":id",$id);
			$stmt->execute();
			
			return true;	
		}
		catch(PDOException $e)
		{
			echo $e->getMessage();	
			return false;
		}
	}
	
	public function delete($id)
	{
		$stmt = $this->db->prepare("DELETE FROM Permit_Requests WHERE request_id=:id");
		$stmt->bindparam(":id",$id);
		$stmt->execute();
		return true;
	}
	
	/* paging */
	
	public function dataview($query)
	{
		$stmt = $this->db->prepare($query);
		$stmt->execute();

        if($stmt->rowCount()>0)
        {
            while($row=$stmt->fetch(PDO::FETCH_ASSOC))
            {
                ?>
                <tr>
                    <td><?php print($row['request_id']); ?></td>
                    <td><?php print($row['submission_date']); ?></td>
					<td>
					<?php 
					if($row['completion_status'] == 1){
						print("Completed");
					}else{
						print("Pending");
					}
					?>
					</td>
                    <td><?php print($row['approval_status']); ?></td>
                    <td><?php print($row['user_id']); ?></td>
                    <td><?php print($row['class_id']); ?></td>
                </tr>
                <?php
            }
        }
        else
		{
			?>
            <tr>
            <td>Nothing here...</td>
            </tr>
            <?php
		}
		
	}

    public function studentdataview($id)
    {

        $stmt = $this->db->prepare("SELECT * FROM Users WHERE user_id= ?");
        $stmt->bindparam(1,$id, PDO::PARAM_STR);
        $stmt->execute();

        if($stmt->rowCount()>0)
        {
            while($row=$stmt->fetch(PDO::FETCH_ASSOC))
            {
                ?>
                <tr>
                    <td><?php print($row['request_id']); ?></td>
                    <td><?php print($row['submission_date']); ?></td>
                    <td>
                        <?php
                        if($row['completion_status'] == 1){
                            print("Completed");
                        }else{
                            print("Pending");
                        }
                        ?>
                    </td>
                    <td><?php print($row['approval_status']); ?></td>
                    <td><?php print($row['user_id']); ?></td>
                    <td><?php print($row['class_id']); ?></td>
                </tr>
                <?php
            }
        }
        else
        {
            ?>
            <tr>
                <td>Nothing here...</td>
            </tr>
            <?php
        }

    }

	public function paging($query,$records_per_page)
	{
		$starting_position=0;
		if(isset($_GET["page_no"]))
		{
			$starting_position=($_GET["page_no"]-1)*$records_per_page;
		}
		$query2=$query." limit $starting_position,$records_per_page";
		return $query2;
	}
	
	public function paginglink($query,$records_per_page)
	{
		
		$self = $_SERVER['PHP_SELF'];
		
		$stmt = $this->db->prepare($query);
		$stmt->execute();
		
		$total_no_of_records = $stmt->rowCount();
		
		if($total_no_of_records > 0)
		{
			?><ul class="pagination"><?php
			$total_no_of_pages=ceil($total_no_of_records/$records_per_page);
			$current_page=1;
			if(isset($_GET["page_no"]))
			{
				$current_page=$_GET["page_no"];
			}
			if($current_page!=1)
			{
				$previous =$current_page-1;
				echo "<li><a href='".$self."?page_no=1'>First</a></li>";
				echo "<li><a href='".$self."?page_no=".$previous."'>Previous</a></li>";
			}
			for($i=1;$i<=$total_no_of_pages;$i++)
			{
				if($i==$current_page)
				{
					echo "<li><a href='".$self."?page_no=".$i."' style='color:red;'>".$i."</a></li>";
				}
				else
				{
					echo "<li><a href='".$self."?page_no=".$i."'>".$i."</a></li>";
				}
			}
			if($current_page!=$total_no_of_pages)
			{
				$next=$current_page+1;
				echo "<li><a href='".$self."?page_no=".$next."'>Next</a></li>";
				echo "<li><a href='".$self."?page_no=".$total_no_of_pages."'>Last</a></li>";
			}
			?></ul><?php
		}
	}
	
	/* paging */
	
}
