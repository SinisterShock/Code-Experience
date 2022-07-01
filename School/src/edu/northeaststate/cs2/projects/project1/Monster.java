package edu.northeaststate.cs2.projects.project1;


/**
 * Class Name: Monster
 * Purpose: Creates a monster with a Name, Armor class, Hit points, and attack damage
 */
public class Monster {
    private String name;
    private int hitPoints;
    private int armorClass;
    private int attackDamage;

    /**
     * Method Name: Monster
     * Method Description: Constructor for Monster
     * @param name
     * @param armorClass
     * @param attackDamage
     * @param hitPoints
     */
    public Monster(String name, int hitPoints, int armorClass, int attackDamage) {
        this.name = name;
        this.hitPoints = hitPoints;
        this.armorClass = armorClass;
        this.attackDamage = attackDamage;
    }
    /**
     * Method Name: getName
     * Method Description: getter for the name
     */
    public String getName() {
        return this.name;
    }
    /**
     * Method Name: setName
     * Method Description: setter for the name
     * @param name
     */
    public void setName(String name) {
        this.name = name;
    }
    /**
     * Method Name: getHitPoints
     * Method Description: getter for the hit points
     */
    public int getHitPoints() {
        return this.hitPoints;
    }
    /**
     * Method Name: setHitPoints
     * Method Description: setter for the Hit Points
     * @param hitPoints
     */
    public void setHitPoints(int hitPoints) {
        this.hitPoints = hitPoints;
    }
    /**
     * Method Name: getArmorClass
     * Method Description: getter for the Armor Class
     */
    public int getArmorClass() {
        return armorClass;
    }
    /**
     * Method Name: setArmorClass
     * Method Description: setter for the ArmorClass
     * @param armorClass
     */
    public void setArmorClass(int armorClass) {
        this.armorClass = armorClass;
    }
    /**
     * Method Name: getAttackDamage
     * Method Description: getter for the Attack Damage
     */
    public int getAttackDamage() {
        return attackDamage;
    }
    /**
     * Method Name: setAttackDamage
     * Method Description: setter for the Attack Damage
     * @param attackDamage
     */
    public void setAttackDamage(int attackDamage) {
        this.attackDamage = attackDamage;
    }
    /**
     * Method Name: toString
     * Method Description: Uses String builder to push the name and value to a string
     */
    @Override
    public String toString() {
        final StringBuilder sb = new StringBuilder("   Monster ");
        sb.append("name='").append(name).append('\'');
        sb.append(", hitPoints=").append(hitPoints).append('\'');
        sb.append(", armorClass=").append(armorClass).append('\'');
        sb.append(", attackDamage=").append(attackDamage);
        return sb.toString();
    }

}
