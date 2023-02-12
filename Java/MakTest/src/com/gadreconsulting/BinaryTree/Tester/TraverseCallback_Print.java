package com.gadreconsulting.BinaryTree.Tester;

import com.gadreconsulting.BinaryTree.IBBTreeTraversalCallback;
import com.gadreconsulting.BinaryTree.Node;


public class TraverseCallback_Print implements IBBTreeTraversalCallback<CityInfo> {

	@Override
	public boolean fHandle(Node<CityInfo> node) {
		CityInfo ciValue = node._tPayload;
		for (int j = 0; j < node._jDist; j++) {
			System.out.print("*********");
		}

		System.out.print(ciValue + "<<");
		if (node._nodeParent == null) {
			System.out.println("ROOT NODE");
		}else {
			System.out.println(node._nodeParent._tPayload);
		}
		return true;
	}

}